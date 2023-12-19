using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.Arm;

namespace Classe
{
    public class SlotMachine
    {

//         SLOT MACHINE
// Creare una classe che permetta di rappresentare una slot machine: deve funzionare ogni moneta inserita da diritto ad una partita in cui  girano le tre rotelle della slot machine e appaiono tre simboli (nel nostro caso tre lettere a caso dall'alfabeto italiano).
// L’utente per sole due volte può decidere di tenere una o più lettere apparse e far girare nuovamente le rotelle o fermarsi.
// Una volta che si ferma:
// - se c’è una coppia viene restituita una moneta 
// - se c’è un tris di lettere uguali vengono restituite un numero di monete pari alla posizione in ordine alfabetico della lettera del tris(es. tre C corrispondono a 3 monete)
// - se ci sono tre lettere consecutive (es. ABC oppure EFG) vengono restituite 50 monete 
// - se ci sono tre Z allora è JACKPOT e vengono restituite 100 monetine
// altrimenti non viene restituito nulla e si passa alla partita successiva inserendo una nuova monetina.
// Le monete vinte possono essere rigiocate oppure riscosse dal giocatore. 

        public int monete = 10;
        public char[] simboli = {'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','W','X','Y','Z'};
        public char[] schermo = new char[3];
        public bool partitaIniziata = false;

        public void gira(){

            System.Console.WriteLine("TESTA LA TUA FORTUNA");
            monete--;
            string risposta;
            partitaIniziata = true;
            Random rnd = new Random();
            int temp = 0;
            if(monete >= 1){
                for (int i = 0; i < schermo.Length; i++){
                    temp = rnd.Next(0,simboli.Length-1);
                    schermo[i] = simboli[temp];
                }

                for (int i = 0; i < schermo.Length; i++){
                    System.Console.Write(schermo[i] + "\n");
                }

                
                ControlloDa50();
              
                if (schermo[0] == schermo[1] && schermo[1] == schermo[2])
                {
                    System.Console.WriteLine($"complimenti hai fatto tris!, + {temp+1} monete, riprovare? (s/n), monete rimaste = {monete}");
                    monete = monete + temp + 1;
                    risposta = Console.ReadLine();
                    partitaIniziata = Continui(risposta);

                } else if (schermo[0] == schermo[1] || schermo[1] == schermo[2] || schermo[0] == schermo[2] )
                {
                    System.Console.WriteLine($"hai fatto una coppia!, +1 monete, riprovare? (s/n), monete rimaste = {monete}");
                    monete++;
                    risposta = Console.ReadLine();
                    partitaIniziata = Continui(risposta);
                    
                } else if (schermo[0] == schermo[1] && schermo[1] == schermo[2] && schermo[0] == 'Z')
                {
                    System.Console.WriteLine($"COMPLIMENTI, HAI FATTO JACKPOT!, +100 monete, riprovare? (s/n), monete rimaste = {monete}");
                    monete+=100;
                    risposta = Console.ReadLine();
                    partitaIniziata = Continui(risposta);
                    
                } else {
                    System.Console.WriteLine($"mi dispiace, non hai vinto, riprovare? (s/n), monete rimaste = {monete}");
                    risposta = Console.ReadLine();
                    partitaIniziata = Continui(risposta);
                }
            } else {
                System.Console.WriteLine("credito insufficiente");
            }
        }

        private void ControlloDa50(){
            monete--;
            string risposta;
            int lettereConsecutive = 0;
            char UltimoSimbolo = schermo[0];
            int temp;

            for ( int i = 0; i < schermo.Length; i++){
                if ((int)UltimoSimbolo == (int)schermo[i]){
                    temp = (int)schermo[i]+1;
                    UltimoSimbolo = Convert.ToChar(temp);
                    lettereConsecutive++;
                }else{
                    lettereConsecutive = 1;
                }
            }

            if (lettereConsecutive == 3){
                System.Console.WriteLine($"hai fatto una serie!, +50 monete, riprovare? (s/n), monete rimaste = {monete}");
                monete = monete + 50;
                risposta = Console.ReadLine();
                partitaIniziata = Continui(risposta);
            }
        }









        private bool Continui(string risposta){
            if (risposta == "s" || risposta == "S" || risposta == "si" || risposta == "Si" || risposta == "sI"){
                return true;
            }else{
                return false;
            }            
        }
    
    }
}