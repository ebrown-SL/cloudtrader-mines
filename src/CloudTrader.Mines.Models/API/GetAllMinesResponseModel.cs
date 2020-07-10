using CloudTrader.Mines.Models.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace CloudTrader.Mines.Models.API
{
    public class GetAllMinesResponseModel
    {
        public List<Mine> Mines { get; set; }

        public GetAllMinesResponseModel() { }

        public GetAllMinesResponseModel(List<Mine> mines)
        {
            Mines = mines;
        }
    }
}
