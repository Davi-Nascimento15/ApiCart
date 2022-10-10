using ApiCart.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseHttpsRedirection();

app.UseSwagger();
app.UseSwaggerUI();

List<Carrinho> ListaCarrinhos = new List<Carrinho>();

app.MapGet("/listacarrinhos", () => Results.Ok(ListaCarrinhos)).WithName("listadeCarrinhos");

app.MapGet("/itensCarrinho/{idCarrinho}", (int idCarrinho) =>
{
    var aux = ListaCarrinhos.FirstOrDefault(item => item.id == idCarrinho);
    if (aux != null)
        return Results.Ok(aux.Itens);
    else
        return Results.NoContent();
}).WithName("itensdocarrinho/{idCarrrinho}");

app.MapPost("/carrinhoadd/{idCarrinho}", (int idCarrinho, Produto produto) =>
{
    var aux = ListaCarrinhos.FirstOrDefault(item => item.id == idCarrinho);
    if (aux != null)
    {
        aux.Itens.Add(produto);
    }
    else
    {
        Carrinho carrinho = new Carrinho(idCarrinho);
        carrinho.Itens.Add(produto);
        ListaCarrinhos.Add(carrinho);
    }
    return Results.Ok(produto);
});

app.MapDelete("/removeritem/{idCarrinho}/{idproduto}", (int idCarrinho, int idproduto) =>
{
    var aux = ListaCarrinhos.FirstOrDefault(item => item.id == idCarrinho);
    if (aux != null)
    {
        var produto = aux.Itens.FirstOrDefault(item => item.codigo == idproduto);
        if (produto != null)
        {
            aux.Itens.Remove(produto);
            return Results.Ok();
        }
        else
        {
            return Results.NoContent();
        }
    }
    else
    {
        return Results.NotFound();
    }
});

app.MapDelete("/removercarrinho/{idCarrinho}", (int idCarrinho) =>
{
    var aux = ListaCarrinhos.FirstOrDefault(item => item.id == idCarrinho);
    if (aux != null)
    {
        ListaCarrinhos.Remove(aux);
        return Results.Ok();
    }
    else
    {
        return Results.NotFound();
    }
});

app.MapGet("/finalizar/{idCarrinho}", (int idCarrinho) =>
{
    var aux = ListaCarrinhos.FirstOrDefault(item => item.id == idCarrinho);
    if (aux != null)
    {
        return Results.Ok(aux.TotalCarrinho());
    }
    else
    {
        return Results.NotFound();
    }

});

app.Run();