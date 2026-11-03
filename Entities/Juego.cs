namespace Parcial.Entities;

public class Juego
{
    private int id;
    private string nombre;
    private string genero;
    private string descripcion;

    public int Id { get => id; set => id = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public string Genero { get => genero; set => genero = value; }
    public string Descripcion { get => descripcion; set => descripcion = value; }

}