using System.Collections.Generic;
using EPlayersMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EplayersMVC.Controllers
{
    [Route("Login")]
    public class LoginController : Controller
    {

        // TempData é para receber coisas curtas e temporárias
        [TempData]
        public string Mensagem { get; set; }

        Jogador jogadorModel = new Jogador();

        public IActionResult Index()
        {

            return View();
        }

        [Route("Logar")]
        public IActionResult Logar(IFormCollection form)
        {

            // Procurar se o usuário que está dentro do form está sendo encontrado dentro do meu arquivo csv
            List<string> jogadoresCSV = jogadorModel.LerTodasAsLinhasCSV("Database/jogador.csv");

            // Método que busca dentro dessa lista / verificar se o usuário é nulo ou não
            var logado = jogadoresCSV.Find(

                // x = cada item
                x =>
                x.Split(";")[3] == form["Email"] &&
                x.Split(";")[4] == form["Senha"]
                // pegar as posições 3,4 e comparar com email e senha
            );

            if (logado != null)
            {
                // comparando, se for diferente de nulo, é porque encontrou o jogador e redireciona pra tela inicial

                // Atribuir um valor dentro da sessao
                HttpContext.Session.SetString("_UserName", logado.Split(";")[1]);
                return LocalRedirect("~/");
                // ~/ Faz voltar pra tela principal, pois pega o caminho raiz e mais nada
            }

            Mensagem = "Dados incorretos, tente novamente!";
            return LocalRedirect("~/Login");
        }

        [Route("Logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("_UserName");
            return LocalRedirect("~/");
        }
    }
}