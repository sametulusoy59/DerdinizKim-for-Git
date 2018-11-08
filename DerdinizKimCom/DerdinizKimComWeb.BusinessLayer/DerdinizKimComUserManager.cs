using DerdinizKimComWeb.DataAccessLayer.EntityFramework;
using DerdinizKimComWeb.Entities;
using DerdinizKimComWeb.Entities.Messages;
using DerdinizKimComWeb.Entities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerdinizKimComWeb.BusinessLayer
{
   public class DerdinizKimComUserManager
    {
        private Repository<User> repo_user = new Repository<User>();
        public BusinessLayerResults<User> RegisterUser(RegisterViewModel data)
        {
           User user=repo_user.Find(x => x.username == data.Username || x.email == data.Email);
            BusinessLayerResults<User> layerResults = new BusinessLayerResults<User>();
            if (user != null)
            {
                if (user.username == data.Username)
                {
                    layerResults.AddError(ErrorMessageCode.UsernameAlreadyExists, "Kullanıcı Adı Kayıtlı");
                }
                if (user.email == data.Email)
                {
                    layerResults.AddError(ErrorMessageCode.UsernameAlreadyExists, "E-posta Adresi Kayıtlı");
                }
            }
            else
            {
                int db_Result = repo_user.Insert(new User()
                {
                    username = data.Username,
                    email = data.Email,
                    password = data.Password,
                    activate = Guid.NewGuid(),
                   
                    aktifmi = false,
                    adminmi = false
                    


                    

                });
                if (db_Result > 1)
                {
                    layerResults.Result=repo_user.Find(x => x.email == data.Email && x.username == data.Username);
                    //aktivasyon maili atılacak
                    //layerResults.Result.ActivateGuid
                }
            }
            return layerResults;
        }
        public BusinessLayerResults<User> LoginUser(LoginViewModel data)
        {
            
            BusinessLayerResults<User> layerResults = new BusinessLayerResults<User>();
            layerResults.Result = repo_user.Find(x => x.username == data.Username && x.password == data.Password);
            if (layerResults.Result != null)
            {
                if (!layerResults.Result.aktifmi)
                {
                    layerResults.Errors.Add("Kullanıcı Aktifleştirilmemiştir.Lütfen E-posta Adresinizi Kontrol Ediniz...");

                }
               
            }
            else
            {
                layerResults.Errors.Add("Kullanıcı Adı yada Şifre Uyuşmuyor...");
            }
            return layerResults;
            //Giriş Kontrolü
            //Hesap Aktife Edilmiş mi?
        }
    }
}
