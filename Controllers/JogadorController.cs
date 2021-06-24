using System;
using System.IO;
using EPlayersMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EplayersMVC.Controllers
{
    [Route("Jogador")]
    public class JogadorController : Controller
    {
        Jogador jogadorModel = new Jogador(); 

        [Route("Listar")]
        public IActionResult Index(){

            ViewBag.jogadores = jogadorModel.LerTodos();
            return View();
        }

        [Route("Cadastrar")]

        public IActionResult Cadastrar(IFormCollection form){
            Jogador novoJogador = new Jogador();
            novoJogador.IdJogador = Int32.Parse(form["IdJogador"]);
            novoJogador.IdEquipe = Int32.Parse(form["IdEquipe"]);
            novoJogador.Nome = form["Nome"];
            novoJogador.Email = form["Email"];
            novoJogador.Senha= form["Senha"];

            jogadorModel.Criar(novoJogador);
            ViewBag.jogadores = jogadorModel.LerTodos();

            return LocalRedirect("~/Jogador/Listar");
        }

        [Route("Excluir/{id}")]

        public IActionResult Excluir(int id){
            jogadorModel.Deletar(id);
            ViewBag.jogadores = jogadorModel.LerTodos();
            return LocalRedirect("~/Jogador/Listar");
        }
    }
}