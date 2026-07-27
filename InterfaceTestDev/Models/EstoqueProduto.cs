namespace InterfaceTestDev.Models

{

    
    public class EstoqueProduto : IEquatable<EstoqueProduto>
    {

        public int Id { get; set; }
        
        public string Referencia { get; set; }

        
        public int SaldoEstoque { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as EstoqueProduto);
        }

        public bool Equals(EstoqueProduto other)
        {
            return other != null &&
                   Referencia == other.Referencia;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Referencia);
        }

        public static bool operator ==(EstoqueProduto left, EstoqueProduto right)
        {
            return EqualityComparer<EstoqueProduto>.Default.Equals(left, right);
        }

        public static bool operator !=(EstoqueProduto left, EstoqueProduto right)
        {
            return !(left == right);
        }
    }
}