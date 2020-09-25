using Microsoft.EntityFrameworkCore;
using OneForDotNet.Core.Interface;
using OneForDotNet.Core.Model;
using OneForDotNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneForDotNet.Core.Service {
    public class EFService : IService {
        public async Task<ModelBase> GetArticle(int id) {
            throw new NotImplementedException();
        }

        public async Task<ModelBase> GetHome() {
            Home home;
            using (OnesDataContext context = new OnesDataContext()) {
                home = new Home();
                home.Ones = context.Ones.ToList();
                home.Articles = context.Articles.ToList();
                home.Questions = context.Questions.ToList();
            }
            var result = new ModelBase() { Status = "OK", Data = home };
            return result;
        }

        public Task<ModelBase> GetQuestion(int id) {
            throw new NotImplementedException();
        }
        public async Task<bool> UpdateHome(Home home) {
            int colum = 0;
            using (OnesDataContext context = new OnesDataContext()) {
                foreach (var item in context.Ones) {
                    context.Ones.Remove(item);
                }
                foreach (var item in context.Articles) {
                    context.Articles.Remove(item);
                }
                foreach (var item in context.Questions) {
                    context.Questions.Remove(item);
                }
                await context.Ones.AddRangeAsync(home.Ones);
                await context.Articles.AddRangeAsync(home.Articles);
                await context.Questions.AddRangeAsync(home.Questions);
                try {
                    colum = await context.SaveChangesAsync();
                }
                catch {
                    colum = -1;
                }
            }
            return colum > -1;
        }
    }
}
