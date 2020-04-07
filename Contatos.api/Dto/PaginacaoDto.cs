namespace Contatos.api.Dto
{
    public class PaginacaoDto
    {
        private int _Page;
        public int Page 
        {
            get 
            {
                if(_Page <= 0)
                {
                    _Page = 0;
                }
                return _Page;
            }
            set
            {
                _Page = value;
            }
        }
        private int _Size;
        public int Size 
        {
            get 
            {
                if(_Size <= 0)
                {
                    _Size = 10;
                }
                return _Size;
            }
            set
            {
                _Size = value;
            }
        }
    }
}