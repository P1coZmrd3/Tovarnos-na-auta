using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp;

namespace projekt_továren.Tridy
{
    internal class Továrna
    {
        Dictionary<string, string> TeslaIndustries = new Dictionary<string, string>()
        {
            {"Model 3", "https://www.hybrid.cz/wp-content/uploads/2013/11/www.hybrid.cz_i_auto_cadillac-world-thorium-fuel-concept-630.jpg" },
            {"Model S", "https://www.autoweb.cz/wp-content/uploads/2020/11/skoda_1000_mb-1100x618.jpg" },
            {"Model X", "https://www.autozive.cz/wp-content/uploads/2021/03/zmrzle-auto-pokus-2-710x467.jpg" },
            {"Model Y", "https://www.motocars.cz/wp-content/uploads/2017/03/video-bananove-auto-755x340.jpg" },
            {"Cybertruck", "https://static8.depositphotos.com/1001599/868/v/600/depositphotos_8681192-stock-illustration-cartoon-car.jpg;ř" }
        };

        public string Menu()
        {
            Console.WriteLine("Vítejte v továrně Tesla");
            Console.WriteLine("V nabidce máme");

            Console.WriteLine("------------------------------");

            Console.WriteLine("Model S");
            Console.WriteLine("Model 3");
            Console.WriteLine("Model X");
            Console.WriteLine("Model Y");
            Console.WriteLine("Cybertruck");

            Console.WriteLine("------------------------------");

            Console.WriteLine("1.Chci zobrazit poslední vytvořené auto");
            Console.WriteLine("2.Chci vytvořit nové auto");

            string input = Console.ReadLine();
            return input;
        }

        public Auto VytvorAuto()
        {
            Console.Clear();
            Auto vyrabeneAuto = new Auto();
            while (true)
            {
                Console.WriteLine("Model S");
                Console.WriteLine("Model 3");
                Console.WriteLine("Model X");
                Console.WriteLine("Model Y");
                Console.WriteLine("Cybertruck");
                Console.WriteLine("------------------------------");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Zadej model : (zadejte přesný název)");
                Console.ForegroundColor = ConsoleColor.White;


                vyrabeneAuto.Model = Console.ReadLine();
                if (this.TeslaIndustries.ContainsKey(vyrabeneAuto.Model))
                {
                    break;
                }

                Console.WriteLine("Nemáme.");
            }

            while (true)
            {
                Console.WriteLine("Zadejte počet sedadel");

                vyrabeneAuto.PocetSedadel = Convert.ToInt32(Console.ReadLine());

                if (vyrabeneAuto.PocetSedadel >= 3 && vyrabeneAuto.PocetSedadel <= 14)
                {
                    break;
                }

                Console.WriteLine("Zvolil jsi počet mimo nabídku ");

            }

            while (true)
            {

                Console.WriteLine("Zadej druh pohonu");


                Console.WriteLine("Elektrický nebo Hybridní");

                vyrabeneAuto.DruhPohonu = Console.ReadLine();

                if (vyrabeneAuto.DruhPohonu == "Elektrický" || vyrabeneAuto.DruhPohonu == "Hybridní")
                {
                    break;
                }

                Console.WriteLine("Mimo nabídku");

            }

            Console.WriteLine("Zadejte požadovanou Cenu:  (des. čísla = čárka");
            vyrabeneAuto.Cena = Convert.ToInt32(Console.ReadLine());

            vyrabeneAuto.Obrazek = TeslaIndustries[vyrabeneAuto.Model];

            return vyrabeneAuto;
        }


        public void VytvorStranku(Auto vyrobeneAuto)
        {
            string html = $@"
            <html>
            <body>
            <h1>Továrna na auta</h1>
            <h2 style='color:blue;'>{vyrobeneAuto.Znacka}</h2>
            <h2>{vyrobeneAuto.Model}</h2>
            <h2>Počet sedaček: {vyrobeneAuto.PocetSedadel}</h2>
            <h2>Druh pohonu: {vyrobeneAuto.DruhPohonu}</h2>
            <img  src='{vyrobeneAuto.Obrazek}'>
            <h3>Rok výroby: {vyrobeneAuto.RokVyroby}</h3>
            <hr>
            <div>
            Cena: <h4 style=' color: orange';>{vyrobeneAuto.Cena}  </h4>
            </div>
            </body>
            </html>";
            File.WriteAllText("index.html", html);
        }



        public void ZobrazStranku(string adresaSouboru)
        {
            var process = new System.Diagnostics.ProcessStartInfo();
            process.UseShellExecute = true;

            process.FileName = adresaSouboru;
            System.Diagnostics.Process.Start(process);
        }
    }
}
