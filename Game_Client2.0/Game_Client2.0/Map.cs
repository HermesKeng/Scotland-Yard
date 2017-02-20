﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Game_Client2._0
{
    class Map
    {
        private String[] taxi_res = {"1 8 9 ","2 10 20 ","3 4 11 12 ","4 3 13 ","5 15 16 ","6 7 29 ","7 6 17 ","8 1 18 19 ","9 1 19 20 ","10 2 11 21 ",
                             "11 3 10 22 ","12 3 23 ","13 4 23 24 ","14 15 25 ","15 5 14 16 26 28 ","16 5 15 28 29 ","17 7 29 30 ","18 8 31 43 ","19 8 9 32 ","20 2 9 33 ",
                             "21 10 33 ","22 11 23 34 35 ","23 12 13 22 37 ","24 13 37 38 ","25 14 38 39 ","26 15 27 39 ","27 26 28 40 ","28 15 16 27 41 ","29 6 16 17 41 42 ","30 17 42 ",
                             "31 18 43 44 ","32 19 33 44 45 ","33 20 21 32 46 ","34 10 22 47 48 ","35 22 36 48 65 ","36 35 37 49 ","37 23 24 36 50 ","38 24 25 50 51 ","39 25 26 51 52 ","40 27 41 52 53 ",
                             "41 28 29 40 54 ","42 29 30 56 72 ","43 18 31 57 ","44 31 32 58 ","45 32 46 58 60 ","46 33 45 47 61 ","47 34 46 62 ","48 34 35 62 63","49 36 50 66 ","50 37 38 49 ",
                             "51 38 39 52 67 68 ","52 39 40 51 69 ","53 40 54 69 ","54 41 53 55 70 ","55 54 71 ","56 42 91 ","57 43 58 73 ","58 44 45 57 59 ","59 45 58 75 76 ","60 45 61 76 ",
                             "61 46 60 62 76 78 ","62 47 48 61 79 ","63 48 64 79 80 ","64 63 65 81 ","65 35 64 66 82 ","66 49 65 67 82 ","67 51 66 68 84 ","68 51 67 69 85 ","69 52 53 68 86 ","70 54 71 87 ",
                             "71 55 70 89 ","72 42 71 90 91 ","73 57 74 92 ","74 58 73 75 92 ","75 58 59 74 94 ","76 59 60 61 77 ","77 76 78 95 96 ","78 61 77 79 97 ","79 62 63 78 98 ","80 63 99 100 ",
                             "81 64 82 100 ","82 65 66 81 101 ","83 101 102 ","84 67 85 ","85 68 84 103 ","86 69 103 104 ","87 70 88 ","88 87 89 117 ","89 71 88 105 ","90 72 91 105 ",
                             "91 56 72 90 105 107 ","92 73 74 93 ","93 92 94 ","94 75 93 95 ","95 77 94 122 ","96 77 97 109 ","97 78 96 98 109 ","98 79 97 99 110 ","99 80 98 110 112 ","100 80 81 101 112 113 ",
                             "101 82 83 100 114 ","102 83 103 115 ","103 85 86 102 ","104 86 116 ","105 89 90 91 106 108 ","106 105 107 ","107 91 106 119 ","108 105 117 119 ","109 96 97 110 124 ","110 98 99 109 111 ",
                             "111 110 112 124 ","112 99 100 111 125 ","113 100 114 125 ","114 101 113 115 126 131 ","115 102 114 126 127 ","116 104 117 118 127 ","117 88 108 116 129 ","118 116 129 134 142 ","119 107 108 136 ","120 121 144 ",
                             "121 120 122 145 ","122 95 121 123 146 ","123 122 124 137 148 149 ","124 109 111 123 130 138 ","125 112 113 131 ","126 114 115 127 140 ","127 115 116 126 133 134 ","128 142 143 160 172 188 ","129 117 118 135 142 143 ","130 124 131 139 ",
                             "131 125 130 114 ","132 114 140 ","133 127 140 141 ","134 118 127 141 142 ","135 129 136 143 161 ","136 119 135 162 ","137 123 147 ","138 124 150 152 ","139 124 150 152 ","140 132 133 139 154 156 ",
                             "141 133 134 142 158 ","142 118 128 134 141 143 158 ","143 128 135 142 160 ","144 120 145 177 ","145 121 144 146 ","146 122 145 147 ","147 137 146 164 ","148 123 149 164 ","149 123 148 150 165 ","150 138 149 151 ",
                             "151 150 152 165 166 ","152 138 151 153 ","153 139 152 154 166 167 ","154 139 140 153 155 ","155 154 156 167 168 ","156 140 155 157 169 ","157 156 158 170 ","158 141 142 157 159 ","159 158 170 172 186 198 ","160 128 143 161 173 ",
                             "161 135 160 174 ","162 136 175 ","163 146 177 ","164 147 148 178 179 ","165 149 151 179 180 ","166 151 153 181 183 ","167 153 155 168 183 ","168 155 167 184 ","169 156 184 ","170 157 159 185 ",
                             "171 173 175 199 ","172 128 159 185 ","173 161 173 175 ","174 161 173 175 ","175 162 171 174 ","176 177 189 ","177 144 163 176 ","178 164 189 191 ","179 164 165 191 ","180 165 181 193 ",
                             "181 166 180 182 193 ","182 181 183 195 ","183 166 167 182 196 ","184 168 169 185 196 ","185 170 184 186 ","186 159 185 198 ","187 172 188 198 ","188 128 173 187 199 ","189 176 178 190 ","190 189 191 192 ",
                             "191 178 179 190 192 ","192 190 191 194 ","193 180 181 194 ","194 192 193 195 ","195 182 194 197 ","196 183 184 197 ","197 195 196 184 ","198 186 187 199 ","199 171 188 196"};
        private String[] bus_res = {"1 46 58 ","3 22 23 ","7 42 "," "};
        private String[] train_res = { };
        private String[] canel_res = { };
        private List<List<int>> taxi_map = new List<List<int>>();
        private List<List<int>> bus_map = new List<List<int>>();
        private List<List<int>> train_map = new List<List<int>>();
        private List<List<int>> canel_map = new List<List<int>>();
        private int [,] PlayerPos=new int[5,25] ;
        private int [,] PlayerTransport = new int[5,5];
        //0:Taxi 1:Bus 2:Train 3:ALL 4:Double
        public Map()
        {
            String line,temp_point;
            
            for (int i = 0; i < 199; i++)
            {
              
                List<int>Temp=new List<int>();
                int position = 0, start = 0;
                line = taxi_res[i];
                do{
                    position=line.IndexOf(" ",start);
                    if(position>=0){
                        temp_point=line.Substring(start,position-start+1).Trim();
                        Temp.Add(Int32.Parse(temp_point));
                        start = position + 1;
                    }
                }
                while(position>0);
                taxi_map.Add(Temp);
            }
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 25; j++)
                {
                    PlayerPos[i,j] = 0;
                }
            }
           
            for (int i = 0; i < 5; i++)
            {
                if (i == 0)
                {
                    PlayerTransport[i, 0] = 4;
                    PlayerTransport[i, 1] = 3;
                    PlayerTransport[i, 2] = 3;
                    PlayerTransport[i, 3] = 2;
                    PlayerTransport[i, 4] = 3;
                }
                else
                {
                    PlayerTransport[i, 0] = 10;
                    PlayerTransport[i, 1] = 8;
                    PlayerTransport[i, 2] = 4;
                    PlayerTransport[i, 3] = 0;
                    PlayerTransport[i, 4] = 0;
                }
            }
        }   
        public bool is_ConnectingVertex(int start,int end,int trans)
        {
            List<int> Temp;
            switch (trans)
            {
                case 0:
                    Temp = taxi_map[start - 1];
                    return Temp.Contains(end);
                case 1:
                    Temp = bus_map[start - 1];
                    return Temp.Contains(end);
                case 2:
                    Temp = train_map[start - 1];
                    return Temp.Contains(end);
                    
                case 3:
                    Temp = canel_map[start - 1];
                    return Temp.Contains(end);
            }
            return false;
        }
            
         
        public int GetPos(int ID,int now)
        {
            return PlayerPos[ID-1,now];
        }
        public int GetTicket(int Player, int trans)
        {
            return PlayerTransport[Player - 1, trans];
        }
        public void CreatePos(int ID,int num)
        {
            PlayerPos[ID-1,0]=num;
        }
        public void SetPos(int Player,int num,int turn)
        {
            PlayerPos[Player-1,turn]=num;
        }
        public void AddTicket(int trans)
        {
            PlayerTransport[0, trans]++;
        }
        public void DeductTicket(int Player, int trans)
        {
            PlayerTransport[Player - 1, trans]--;
        }
    }
}
