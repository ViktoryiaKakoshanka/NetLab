namespace WpfPhone.Model
{
    public class Phone
    {
        private string _title;
        private string _company;
        private int _price;
        
        public string Title
        {
            get => _title;
            set
            {
                if (value != null && value == _title)
                {
                    return;
                }
                _title = value;
            }
        }

        public string Company
        {
            get => _company;
            set
            {
                if (value != null && value == _company)
                {
                    return;
                }
                _company = value;
            }
        }

        public int Price
        {
            get => _price;
            set
            {
                if (value.Equals(_price))
                {
                    return;
                }
                _price = value;
            }
        }
    }
}
