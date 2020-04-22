namespace Domain
{
    //Информация о фирме-поставщике
    public class Supplier
    {
        //Идентификатор
        public int Id { get; set; }
        
        //Название фирмы
        public string Name { get; set; }

        //Адрес
        public string Address { get; set; }
    }
}