using SesionesCliente.Context;
var onlineContext = new BDOnlineContext();
var tecnologiasContext = new BDTecnologiasContext();
var seguridadPJContext = new BDSeguridadPJContext();


var sesion = onlineContext.CMP_Sesion.Where(x => x.SesionId == 27727).First();
var contadorAnterior = tecnologiasContext.Contadores_OnLine
    .OrderByDescending(x => x.Fecha)
    .Where(x => x.Fecha <= sesion.FechaInicio)
    .Where(x=>x.CodMaq==sesion.CodMaquina)
    .FirstOrDefault();
var factorMaquina = seguridadPJContext.CMP_FactorMaquina.Where(x => x.CodMaquina == sesion.CodMaquina).FirstOrDefault();
decimal factorMultiplicador = 1;
if(factorMaquina != null) {
    factorMultiplicador = factorMaquina.FactorMultiplicador;
}
bool continuarTarea = true;
var contadores = tecnologiasContext.Contadores_OnLine
    .Where(x => x.Fecha >= sesion.FechaInicio)
    .Where(x => x.Fecha <= sesion.FechaTermino)
    .Where(x => x.CodMaq == sesion.CodMaquina)
    .OrderBy(x => x.Fecha)
    .ToList();
DateTime tiempo = Convert.ToDateTime(sesion.FechaInicio);
const int segundosTarea = 5;
bool primeraVez = true;
while (continuarTarea) {
    var contadorNuevo = contadores.Where(x => x.Fecha >= tiempo).OrderBy(x => x.Fecha).FirstOrDefault();
    if (primeraVez) {
        contadorAnterior = contadorNuevo;
        primeraVez = false;
        continue;
    } 
    if (contadorNuevo == null) {
        continuarTarea = false;
        continue;
    }
    if (contadorAnterior == null) {
        continuarTarea = false;
        continue;
    }
    if (contadorNuevo.CurrentCredits > 0.1) {
        if (contadorNuevo.CoinOut != contadorAnterior.CoinOut && contadorNuevo.CoinOut > contadorAnterior.CoinOut && contadorAnterior.CoinOut > 0 && contadorNuevo.CoinOut > 0) {
            var listaSorteos = seguridadPJContext.CMP_SorteoSala.Where(x => x.Estado == 1);
            if (listaSorteos.Count() > 0){
                double Token = Convert.ToDouble(contadorNuevo.Token);
                double cantidadFormulaBet = (contadorNuevo.CoinIn - contadorAnterior.CoinIn) * Token;
                double cantidadFormulaWin =
                    (double)(
                        (contadorNuevo.CoinOut - contadorAnterior.CoinOut) +
                        (contadorNuevo.HandPay - contadorAnterior.HandPay) +
                        (contadorNuevo.Jackpot - contadorAnterior.Jackpot)
                    ) * Token;

                foreach(var sorteo in listaSorteos) {
                    int cantidadCupones = 0;
                    decimal descartexFactor = 0;
                    if (sorteo.CondicionBet > 0 && sorteo.CondicionWin > 0) {
                        //Evaluar para bet y si cumple condicion de bet, evaluar cantidad de cupones en base a condicion win
                        if (cantidadFormulaBet >= (double)sorteo.CondicionBet) {
                            //cumple condicion, entonces se evalua para cantidad de cupones en base a condicion win
                            cantidadCupones = (int)((cantidadFormulaWin * (double)factorMultiplicador) / (double)sorteo.CondicionWin);
                            descartexFactor = (decimal)(cantidadFormulaWin / (double)sorteo.CondicionWin);
                        }
                    } else if (sorteo.CondicionBet > 0 && sorteo.CondicionWin == 0) {
                        //Evaluar cantidad de cupones para condicion Bet
                        cantidadCupones = (int)((cantidadFormulaBet * (double)factorMultiplicador) / (double)sorteo.CondicionBet);
                        descartexFactor = (int)(cantidadFormulaBet / (double)sorteo.CondicionBet);
                    } else if (sorteo.CondicionBet == 0 && sorteo.CondicionWin > 0) {
                        //Evaluar cantidad de cupones en base a win solamente(forma normal)
                        cantidadCupones = (int)((cantidadFormulaWin * (double)factorMultiplicador) / (double)sorteo.CondicionWin);
                        descartexFactor = (int)(cantidadFormulaWin / (double)sorteo.CondicionWin);
                    }

                    cantidadCupones = cantidadCupones >= (int)sorteo.TopeCuponesxJugada ? (int)sorteo.TopeCuponesxJugada : cantidadCupones;
                    descartexFactor = descartexFactor >= sorteo.TopeCuponesxJugada ? (int)sorteo.TopeCuponesxJugada : descartexFactor;

                    Console.WriteLine($@"Cod_Cont_OL = {contadorNuevo.Cod_Cont_OL} ; Cod_Cont_OLAnterior = {contadorAnterior.Cod_Cont_OL}; CoinIn = {contadorNuevo.CoinIn}; CoinInAnterior = {contadorAnterior.CoinIn} ; CantidadFormulaWin = {cantidadFormulaWin} ; CantidadFormulaBet = {cantidadFormulaBet} ; CantidadCupones = {cantidadCupones}");

                }
            }
               

            //Console.WriteLine($@"Cod_Cont_OL = {contadorNuevo.Cod_Cont_OL} ; Cod_Cont_OLAnterior = {contadorAnterior.Cod_Cont_OL}");
            contadorAnterior = contadorNuevo;
        }
    } 
    else {
        continuarTarea = false;
    }
    
   
    tiempo=tiempo.AddSeconds(segundosTarea);

}
Console.ReadKey();