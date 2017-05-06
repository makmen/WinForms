using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DbBank.XML;

namespace DbBank
{
    public class BankDb
    {
        private BanksEntities dbLink;

        public BankDb()
        {
            dbLink = new BanksEntities();
        }

        public void UpdateKurs(banks banks)
        {
            foreach (var item in banks.bankid)
            {
                Bank singleBank =
                    (from bankdb in dbLink.Bank
                     where bankdb.idparsebank == item.idbank
                     select bankdb).FirstOrDefault();
                singleBank.datekurs = item.date;
                singleBank.time = (int)(new TimeSpan(item.time.Hour, item.time.Minute, item.time.Second)).TotalSeconds;
                singleBank.usdbuy = item.usd.buy;
                singleBank.usdsell = item.usd.sell;
                singleBank.eurbuy = item.eur.buy;
                singleBank.eursell = item.eur.sell;
                singleBank.rurbuy = (double)item.rur.buy;
                singleBank.rursell = (double)item.rur.sell;
                dbLink.SaveChanges();
            }
        }

        public bool EditAtm(Atm newAtm)
        {
            Atm singleAtm =
                (from atmdb in dbLink.Atm
                 where atmdb.id == newAtm.id
                 select atmdb).FirstOrDefault();
            try
            {
                singleAtm.title = newAtm.title;
                singleAtm.phone = newAtm.phone;
                singleAtm.addressatm = newAtm.addressatm;
                singleAtm.gpsX = newAtm.gpsX;
                singleAtm.gpsY = newAtm.gpsY;
                singleAtm.dateregister = newAtm.dateregister;
                singleAtm.mainoffice = newAtm.mainoffice;
                singleAtm.timeopen = newAtm.timeopen;
                singleAtm.timeclose = newAtm.timeclose;
                singleAtm.cashier = newAtm.cashier;
                singleAtm.description = newAtm.description;
                singleAtm.idbank = newAtm.idbank;
                singleAtm.Service = newAtm.Service;
                dbLink.SaveChanges();
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return false;
            }

            return true;
        }


        public Bank SingleBank(int idparse)
        {
            Bank singleBank =
                (from bankdb in dbLink.Bank
                 where bankdb.idparsebank == idparse
                 select bankdb).FirstOrDefault();

            return singleBank;
        }

        public List<Atm> GetAllAtm()
        {
            List<Atm> atm =
                (from at in dbLink.Atm
                 select at).ToList();

            return atm;
        }

        public List<Bank> GetAllBanks()
        {
            List<Bank> banks =
                (from bank in dbLink.Bank
                 select bank).ToList();

            return banks;
        }

        public List<Service> GetAllServices()
        {
            List<Service> services =
                (from service in dbLink.Service
                 select service).ToList();

            return services;
        }

        public List<Atm> GetAllClosestAtm(double x, double y, int num)
        {
            var closestAtm =
                from at in dbLink.Atm
                 select new
                 {
                     id = at.id,
                     gpsX = at.gpsX,
                     gpsY = at.gpsY,
                     delta = ((at.gpsX - x) * (at.gpsX - x) + (at.gpsY - y) * (at.gpsY - y))
                     // не понятно почему не работает delta = Math.Sqrt((at.gpsX - x) * (at.gpsX - x) + (at.gpsY - y) * (at.gpsY - y))
                 };
            Dictionary<int, double> sqrtDelta = new Dictionary<int, double>();
            foreach (var item in closestAtm)
            {
                sqrtDelta.Add(item.id, Math.Sqrt(item.delta));
            }
            var tempAtm =
                (from item in sqrtDelta
                 orderby item.Value
                 select item).Take(num);
            List<Atm> atm = new List<Atm>();
            foreach(var item in tempAtm)
            {
                atm.Add((
                    from atmdb in dbLink.Atm
                    where atmdb.id == item.Key
                    select atmdb).FirstOrDefault()
                );
            }

            return atm;
        }

        public List<Bank> GetMinMaxRates(string search, int num)
        {
            List<Bank> banks = new List<Bank>();
            if (search == "usd")
            {
                banks =
                    (from bank in dbLink.Bank
                     orderby bank.usdbuy
                     select bank).Take(num).ToList();
            }
            else if (search == "eur")
            {
                banks =
                    (from bank in dbLink.Bank
                     orderby bank.eurbuy
                     select bank).Take(num).ToList();
            }
            else
            {
                banks =
                    (from bank in dbLink.Bank
                     orderby bank.rurbuy
                     select bank).Take(num).ToList();
            }

            return banks;
        }
        
        public bool AddService(Service newService)
        {
            try
            {
                dbLink.Service.Add(newService);
                dbLink.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool AddAtm(Atm newAtm)
        {
            try
            {
                dbLink.Atm.Add(newAtm);
                dbLink.SaveChanges();
            }
            catch(Exception)
            {
                return false;
            }

            return true;
        }

        public List<Atm> GetAtmFilters(Atm newAtm, bool mainOffice)
        {
            List<Atm> search = new List<Atm>();; // здесь будут хранится результаты поиска
            // берем все atm
            List<Atm> atm =
                (from atmdb in dbLink.Atm
                 select atmdb).ToList();

            if (newAtm.Bank != null) // банки
            {
                search =
                    (from atmdb in atm
                     where atmdb.idbank == newAtm.Bank.id
                     select atmdb).ToList();
                atm = search;
            }

            if (newAtm.Service.Count > 0)
            {
                search = new List<Atm>();
                bool result = false;
                foreach (Atm itemAtm in atm) // прогоняем Atm 
                {
                    foreach (Service item in newAtm.Service) // берем все услуги по фильтру они все должны быть в atm 
                    {
                        result = false;
                        foreach (Service itemService in itemAtm.Service)
                        {
                            if (itemService.id == item.id)
                            {
                                result = true;
                                break;
                            }
                        }
                        if (!result) // дальше искать нет смысла
                        {
                            break;
                        }
                    }
                    if (result)
                    {
                        search.Add(itemAtm);
                    }
                }
                atm = search;
            }
            if (newAtm.timeopen > 0 && newAtm.timeclose > 0) // время работы
            {
                search = new List<Atm>();
                search =
                    (from atmdb in atm
                     where atmdb.timeopen >= newAtm.timeopen &&
                         atmdb.timeclose >= newAtm.timeclose
                     select atmdb).ToList();
                atm = search;
            }

            if (mainOffice) // главные оффисы 
            {
                search = new List<Atm>();
                search =
                (from atmdb in atm
                 where atmdb.mainoffice == newAtm.mainoffice
                 select atmdb).ToList();
                atm = search;
            }

            return atm;
        }
    }
}
