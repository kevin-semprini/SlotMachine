namespace Classe;

using System.Net.WebSockets;
using Classe;

internal class Program{

    static void Main(){
        
        SlotMachine slotMachine = new SlotMachine();
        do{
            slotMachine.gira();
        }while(slotMachine.partitaIniziata);
        
    }
}