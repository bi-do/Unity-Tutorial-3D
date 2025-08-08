using System;
using System.Collections.Generic;
using UnityEngine;

public class WeatherData
{
    [Serializable]
    public class Root
    {
        public Response response;
    }

    [Serializable]
    public class Response
    {
        public Header header;
        public body body;
    }

    [Serializable]
    public class Header
    {
        public string resultCode;
        public string resultMsg;
    }

    [Serializable]
    public class body
    {
        public string dataType;
        public Items items;
        public string pageNo;
        public string numOfRows;
        public string totalCount;
    }

    [Serializable]
    public class Items
    {
        public List<Item> item;

    }

    [Serializable]
    public class Item
    {
        
        // public string category;
        // public string fcst_date;
        // public string fcst_time;
        // public string fcst_value;

        public string baseDate;
        public string baseTime;
        public string category;
        public string fcstDate;
        public string fcstTime;
        public string fcstValue;
        public string nx;
        public string ny;
    }
}