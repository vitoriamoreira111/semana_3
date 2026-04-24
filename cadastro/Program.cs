using cadastro.Models;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseUrls("http://localhost:8000");

var app = builder.Build();

Funcionario[] funcionarios = new Funcionario[100];
int contador = 0;

app.MapGet("/",() =>{
  return Results.Ok("APi funcionando com ASP.NET");
});

app.MapGet("/for",() =>{
  for(int i = 0; i < 5;i++){
    Console.WriteLine(i);
  }

});
app.MapGet("/while",() =>{
    int i = 0;
  while(i < 5){
   Console.WriteLine(i);
   i++;
  }

});

app.MapGet("/objeto/{nome}",(string nome) =>{
  Funcionario funcionario = new();

  funcionario.Nome = nome;

  Console.WriteLine("Nome: " + funcionario.Nome);
  return Results.Ok(new {
    nome
});
});
app.MapGet("/vetor",() =>  {
  int[] numeros = new int[3];

  numeros[0] = 10;
  numeros[1] = 55;
  numeros[2] = 77;

  Console.WriteLine("Valor: " + numeros[0]);
  Console.WriteLine("Valor: " + numeros[1]);
  Console.WriteLine("Valor: " + numeros[2]);

  return Results.Ok(new {
    numeros
  });
});
app.MapGet("/vetor/funcionario/{nome}", (string nome) => {
  Funcionario funcionario = new Funcionario();

  funcionario.Nome = nome;

  funcionarios[contador] = funcionario;
  contador++;

  return Results.Ok(new {
    funcionarios
  });

});
app.MapGet("/vetor/funcionarios", () => {
  for(int i = 0; i < contador; i++) {
    Console.WriteLine("Funcionario:" + funcionarios[i].Nome);
  }
});
app.Run();
