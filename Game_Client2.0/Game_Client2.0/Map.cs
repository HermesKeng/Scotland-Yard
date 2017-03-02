using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Game_Client2._0
{
    class Map
    {
        private String[] taxi_res = {"1 8 9 ","2 10 20 ","3 4 11 12 ","4 3 13 ","5 15 16 ","6 7 29 ","7 6 17 ","8 1 18 19 ","9 1 19 20 ","10 2 11 21 34 ",
                             "11 3 10 22 ","12 3 23 ","13 4 23 24 ","14 15 25 ","15 5 14 16 26 28 ","16 5 15 28 29 ","17 7 29 30 ","18 8 31 43 ","19 8 9 32 ","20 2 9 33 ",
                             "21 10 33 ","22 11 23 34 35 ","23 12 13 22 37 ","24 13 37 38 ","25 14 38 39 ","26 15 27 39 ","27 26 28 40 ","28 15 16 27 41 ","29 6 16 17 41 42 ","30 17 42 ",
                             "31 18 43 44 ","32 19 33 44 45 ","33 20 21 32 46 ","34 10 22 47 48 ","35 22 36 48 65 ","36 35 37 49 ","37 23 24 36 50 ","38 24 25 50 51 ","39 25 26 51 52 ","40 27 41 52 53 ",
                             "41 28 29 40 54 ","42 29 30 56 72 ","43 18 31 57 ","44 31 32 58 ","45 32 46 58 60 ","46 33 45 47 61 ","47 34 46 62 ","48 34 35 62 63 ","49 36 50 66 ","50 37 38 49 ",
                             "51 38 39 52 67 68 ","52 39 40 51 69 ","53 40 54 69 ","54 41 53 55 70 ","55 54 71 ","56 42 91 ","57 43 58 73 ","58 44 45 57 59 ","59 45 58 75 76 ","60 45 61 76 ",
                             "61 46 60 62 76 78 ","62 47 48 61 79 ","63 48 64 79 80 ","64 63 65 81 ","65 35 64 66 82 ","66 49 65 67 82 ","67 51 66 68 84 ","68 51 67 69 85 ","69 52 53 68 86 ","70 54 71 87 ",
                             "71 55 70 72 89 ","72 42 71 90 91 ","73 57 74 92 ","74 58 73 75 92 ","75 58 59 74 94 ","76 59 60 61 77 ","77 76 78 95 96 ","78 61 77 79 97 ","79 62 63 78 98 ","80 63 99 100 ",
                             "81 64 82 100 ","82 65 66 81 101 ","83 101 102 ","84 67 85 ","85 68 84 103 ","86 69 103 104 ","87 70 88 ","88 87 89 117 ","89 71 88 105 ","90 72 91 105 ",
                             "91 56 72 90 105 107 ","92 73 74 93 ","93 92 94 ","94 75 93 95 ","95 77 94 122 ","96 77 97 109 ","97 78 96 98 109 ","98 79 97 99 110 ","99 80 98 110 112 ","100 80 81 101 112 113 ",
                             "101 82 83 100 114 ","102 83 103 115 ","103 85 86 102 ","104 86 116 ","105 89 90 91 106 108 ","106 105 107 ","107 91 106 119 ","108 105 117 119 ","109 96 97 110 124 ","110 98 99 109 111 ",
                             "111 110 112 124 ","112 99 100 111 125 ","113 100 114 125 ","114 101 113 115 126 131 132 ","115 102 114 126 127 ","116 104 117 118 127 ","117 88 108 116 129 ","118 116 129 134 142 ","119 107 108 136 ","120 121 144 ",
                             "121 120 122 145 ","122 95 121 123 146 ","123 122 124 137 148 149 ","124 109 111 123 130 138 ","125 112 113 131 ","126 114 115 127 140 ","127 115 116 126 133 134 ","128 142 143 160 172 188 ","129 117 118 135 142 143 ","130 124 131 139 ",
                             "131 125 130 114 ","132 114 140 ","133 127 140 141 ","134 118 127 141 142 ","135 129 136 143 161 ","136 119 135 162 ","137 123 147 ","138 124 150 152 ","139 130 140 153 154 ","140 132 133 139 154 156 ",
                             "141 133 134 142 158 ","142 118 128 134 141 143 158 ","143 128 135 142 160 ","144 120 145 177 ","145 121 144 146 ","146 122 145 147 ","147 137 146 164 ","148 123 149 164 ","149 123 148 150 165 ","150 138 149 151 ",
                             "151 150 152 165 166 ","152 138 151 153 ","153 139 152 154 166 167 ","154 139 140 153 155 ","155 154 156 167 168 ","156 140 155 157 169 ","157 156 158 170 ","158 141 142 157 159 ","159 158 170 172 186 198 ","160 128 143 161 173 ",
                             "161 135 160 174 ","162 136 175 ","163 146 177 ","164 147 148 178 179 ","165 149 151 179 180 ","166 151 153 181 183 ","167 153 155 168 183 ","168 155 167 184 ","169 156 184 ","170 157 159 185 ",
                             "171 173 175 199 ","172 128 159 187 ","173 160 171 174 188 ","174 161 173 175 ","175 162 171 174 ","176 177 189 ","177 144 163 176 ","178 164 189 191 ","179 164 165 191 ","180 165 181 193 ",
                             "181 166 180 182 193 ","182 181 183 195 ","183 166 167 182 196 ","184 168 169 185 196 197","185 170 184 186 ","186 159 185 198 ","187 172 188 198 ","188 128 173 187 199 ","189 176 178 190 ","190 189 191 192 ",
                             "191 178 179 190 192 ","192 190 191 194 ","193 180 181 194 ","194 192 193 195 ","195 182 194 197 ","196 183 184 197 ","197 195 196 184 ","198 159 186 187 199 ","199 171 188 198 "};
        private String[] bus_res = {"1 46 58 ","3 22 23 ","7 42 ","13 14 23 52 ","14 13 15 ","15 14 29 41 ","22 3 23 34 65 ","23 3 13 22 67 ","29 15 41 42 55 ","34 22 46 63 ","41 15 29 52 87 "
                                    ,"42 7 29 72 ","46 1 34 58 78 ","52 13 41 67 86 ","55 29 89 ","58 1 46 74 77 ","63 34 79 65 100 ","65 22 63 67 82 ","67 23 52 65 82 102 ","72 42 105 107 ","74 58 94 "
                                    ,"77 58 94 78 124 ","78 46 77 79 ","79 78 63 ","82 65 67 100 140 ","86 52 87 102 116 ","87 41 86 105 ","89 55 105 ","93 94 ","94 74 77 93 ","100 63 82 111 ","102 67 86 127 "
                                    ,"105 72 87 89 107 108 ","107 72 105 161 ","108 105 116 135 ","111 100 124 ","116 86 108 127 142 ","122 123 144 ","123 122 124 144 165 ","124 77 111 123 153 ","127 102 116 133 "
                                    ,"128 135 142 161 187 199 ","133 127 140 157 ","135 108 128 161 ","140 82 133 154 156 ","142 116 128 157 ","144 122 123 163 ","153 124 154 180 184 ","154 140 153 156 ","156 140 154 157 184 "
                                    ,"157 133 142 156 185 ","161 107 128 135 199 ","163 144 176 191 ","165 123 180 191 ","176 163 190 ","180 153 165 184 190 ","184 153 156 180 185 ","185 157 184 187 ","187 128 185 ","190 176 180 191 "
                                    ,"191 163 165 190 ","199 128 161 "};
        private String[] train_res = {"1 46 ","13 46 67 89 ","46 1 13 74 79 ","67 13 79 89 111 ","74 46 ","79 46 67 93 111 ","89 13 67 140 128 ","93 79 ","111 67 79 153 163 ","128 89 140 185 ","140 89 128 153 ","153 111 140 163 185 ","163 111 153 "
                                      ,"185 128 153 "};
        private String[] canel_res = {"108 115 ","115 108 157 ","157 115 194 ","194 157 " };
        private List<List<int>> taxi_map = new List<List<int>>();
        private List<List<int>> bus_map = new List<List<int>>();
        private List<List<int>> train_map = new List<List<int>>();
        private List<List<int>> canel_map = new List<List<int>>();
        private int [,] PlayerPos=new int[5,25] ;
        private int [,] PlayerTransport = new int[5,5];
        //0:Taxi 1:Bus 2:Train 3:ALL 4:Double
        private void CreatLink() {
            String line, temp_point;

            for (int i = 0; i < taxi_res.Length; i++)
            {

                List<int> Temp = new List<int>();
                int position = 0, start = 0;
                line = taxi_res[i];
                do
                {
                    position = line.IndexOf(" ", start);
                    if (position >= 0)
                    {
                        temp_point = line.Substring(start, position - start + 1).Trim();
                        Temp.Add(Int32.Parse(temp_point));
                        start = position + 1;
                    }
                }
                while (position > 0);
                taxi_map.Add(Temp);
            }
            for (int i = 0; i < bus_res.Length; i++)
            {
                List<int> Temp = new List<int>();
                int position = 0, start = 0;
                line = bus_res[i];
                do
                {
                    position = line.IndexOf(" ", start);
                    if (position >= 0)
                    {
                        temp_point = line.Substring(start, position - start + 1).Trim();
                        Temp.Add(Int32.Parse(temp_point));
                        start = position + 1;
                    }
                } while (position > 0);
                bus_map.Add(Temp);
            }
            for (int i = 0; i < train_res.Length; i++)
            {
                List<int> Temp = new List<int>();
                int position = 0, start = 0;
                line = train_res[i];
                do
                {
                    position = line.IndexOf(" ", start);
                    if (position >= 0)
                    {
                        temp_point = line.Substring(start, position - start + 1).Trim();
                        Temp.Add(Int32.Parse(temp_point));
                        start = position + 1;
                    }
                } while (position > 0);
                train_map.Add(Temp);
            }
            for (int i = 0; i < canel_res.Length; i++)
            {
                List<int> Temp = new List<int>();
                int position = 0, start = 0;
                line = canel_res[i];
                do
                {
                    position = line.IndexOf(" ", start);
                    if (position >= 0)
                    {
                        temp_point = line.Substring(start, position - start + 1).Trim();
                        Temp.Add(Int32.Parse(temp_point));
                        start = position + 1;
                    }
                } while (position > 0);
                canel_map.Add(Temp);
            }
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 25; j++)
                {
                    PlayerPos[i, j] = 0;
                }
            }
        }
        private void SetTicket()
        {
            for (int i = 0; i < 5; i++)
            {
                if (i == 0)
                {
                    PlayerTransport[i, 0] = 1000;//4
                    PlayerTransport[i, 1] = 1000;//3
                    PlayerTransport[i, 2] = 1000;//3
                    PlayerTransport[i, 3] = 1000;//3
                    PlayerTransport[i, 4] = 1000;//2
                }
                else
                {
                    PlayerTransport[i, 0] = 1000;//10
                    PlayerTransport[i, 1] = 1000;//8
                    PlayerTransport[i, 2] = 1000;//4
                    PlayerTransport[i, 3] = 1000;//0
                    PlayerTransport[i, 4] = 1000;//0
                }
            }
        }
        public Map()
        {
            CreatLink();
            SetTicket();
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
                    for (int i = 0; i < bus_map.Count; i++)
                    {
                        if (bus_map[i][0] == start)
                        {
                            Temp = bus_map[i];
                            return Temp.Contains(end);
                        }
                    }
                    break;
                case 2:
                    for (int i = 0; i < train_map.Count; i++)
                    {
                        if (train_map[i][0] == start)
                        {
                            Temp = train_map[i];
                            return Temp.Contains(end);
                        }
                    }
                    break;
                case 3:
                    //檢查運河->檢察地鐵->檢查巴士->檢查計程車
                    for (int i = 0; i < canel_map.Count; i++)
                    {
                        if (canel_map[i][0] == start)
                        {
                            Temp = canel_map[i];
                            if (Temp.Contains(end))
                            {
                                return true;
                            }
                        }
                    }
                    for (int i = 0; i < train_map.Count; i++)
                    {
                        if (train_map[i][0] == start)
                        {
                            Temp = train_map[i];
                            if (Temp.Contains(end))
                            {
                                return true;
                            }
                        }
                    }
                    for (int i = 0; i < bus_map.Count; i++)
                    {
                        if (bus_map[i][0] == start)
                        {
                            Temp = bus_map[i];
                            if (Temp.Contains(end))
                            {
                                return true;
                            }
                        }
                    }

                    Temp = taxi_map[start - 1];
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
        public bool CheckTicket(int PlayerID,int trans)
        {
            if(PlayerTransport[PlayerID-1,trans]>0){
                return true;
            }
            return false;
        }
        public int[] GetCoordinate(int point)
        {
            
            int[] coordinate={0,0};
            switch (point){
                case 1:
                    coordinate[0] = 150;
                    coordinate[1] = 26;
                    break;
                case 2:
                    coordinate[0] = 413;
                    coordinate[1] = 5;
                    break;
                case 3:
                    coordinate[0] = 584;
                    coordinate[1] = 11;
                    break;
                case 4:
                    coordinate[0] = 729;
                    coordinate[1] = 6;
                    break;
                case 5:
                    coordinate[0] = 1144;
                    coordinate[1] = 16;
                    break;
                case 6:
                    coordinate[0] = 1274;
                    coordinate[1] = 33;
                    break;
                case 7:
                    coordinate[0] = 1399;
                    coordinate[1] = 19;
                    break;
                case 8:
                    coordinate[0] = 88;
                    coordinate[1] = 90;
                    break;
                case 9:
                    coordinate[0] = 192;
                    coordinate[1] = 102;
                    break;
                case 10:
                    coordinate[0] = 502;
                    coordinate[1] = 86;
                    break;
                case 11:
                    coordinate[0] = 615;
                    coordinate[1] = 104;
                    break;
                case 12:
                    coordinate[0] = 680;
                    coordinate[1] = 93;
                    break;
                case 13:
                    coordinate[0] = 760;
                    coordinate[1] =79;
                    break;
                case 14:
                    coordinate[0] = 888;
                    coordinate[1] = 49;
                    break;
                case 15:
                    coordinate[0] = 1019;
                    coordinate[1] = 34;
                    break;
                case 16:
                    coordinate[0] =1166;
                    coordinate[1] = 81;
                    break;
                case 17:
                    coordinate[0] = 1352;
                    coordinate[1] = 114;
                    break;
                case 18:
                    coordinate[0] = 32;
                    coordinate[1] = 144;
                    break;
                case 19:
                    coordinate[0] = 171;
                    coordinate[1] = 162;
                    break;
                case 20:
                    coordinate[0] = 291;
                    coordinate[1] = 129;
                    break;
                case 21:
                    coordinate[0] = 388;
                    coordinate[1] = 170;
                    break;
                case 22:
                    coordinate[0] = 576;
                    coordinate[1] = 188;
                    break;
                case 23:
                    coordinate[0] = 677;
                    coordinate[1] = 139;
                    break;
                case 24:
                    coordinate[0] = 834;
                    coordinate[1] = 143;
                    break;
                case 25:
                    coordinate[0] = 938;
                    coordinate[1] = 159;
                    break;
                case 26:
                    coordinate[0] = 999;
                    coordinate[1] = 89;
                    break;
                case 27:
                    coordinate[0] = 1058;
                    coordinate[1] = 169;
                    break;
                case 28:
                    coordinate[0] = 1103;
                    coordinate[1] = 139;
                    break;
                case 29:
                    coordinate[0] = 1230;
                    coordinate[1] = 156;
                    break;
                case 30:
                    coordinate[0] = 1437;
                    coordinate[1] = 148;
                    break;
                case 31:
                    coordinate[0] = 70;
                    coordinate[1] = 196;
                    break;
                case 32:
                    coordinate[0] = 1230;
                    coordinate[1] = 156;
                    break;
                case 33:
                    coordinate[0] = 367;
                    coordinate[1] = 202;
                    break;
                case 34:
                    coordinate[0] =512;
                    coordinate[1] = 221;
                    break;
                case 35:
                    coordinate[0] = 612;
                    coordinate[1] =256;
                    break;
                case 36:
                    coordinate[0] = 669;
                    coordinate[1] = 247;
                    break;
                case 37:
                    coordinate[0] = 722;
                    coordinate[1] = 203;
                    break;
                case 38:
                    coordinate[0] = 866;
                    coordinate[1] = 203;
                    break;
                case 39:
                    coordinate[0] = 974;
                    coordinate[1] = 198;
                    break;
                case 40:
                    coordinate[0] = 1050;
                    coordinate[1] = 233;
                    break;
                case 41:
                    coordinate[0] = 1121;
                    coordinate[1] = 203;
                    break;
                case 42:
                    coordinate[0] = 1357;
                    coordinate[1] = 226;
                    break;
                case 43:
                    coordinate[0] = 45;
                    coordinate[1] = 253;
                    break;
                case 44:
                    coordinate[0] = 190;
                    coordinate[1] = 281;
                    break;
                case 45:
                    coordinate[0] = 256;
                    coordinate[1] = 288;
                    break;
                case 46:
                    coordinate[0] = 339;
                    coordinate[1] = 262;
                    break;
                case 47:
                    coordinate[0] = 452;
                    coordinate[1] = 267;
                    break;
                case 48:
                    coordinate[0] = 566;
                    coordinate[1] = 317;
                    break;
                case 49:
                    coordinate[0] = 738;
                    coordinate[1] = 310;
                    break;
                case 50:
                    coordinate[0] = 805;
                    coordinate[1] = 263;
                    break;
                case 51:
                    coordinate[0] = 946;
                    coordinate[1] = 287;
                    break;
                case 52:
                    coordinate[0] = 1019;
                    coordinate[1] = 267;
                    break;
                case 53:
                    coordinate[0] = 1061;
                    coordinate[1] = 289;
                    break;
                case 54:
                    coordinate[0] = 1149;
                    coordinate[1] = 266;
                    break;
                case 55:
                    coordinate[0] = 1240;
                    coordinate[1] = 262;
                    break;
                case 56:
                    coordinate[0] = 1405;
                    coordinate[1] = 280;
                    break;
                case 57:
                    coordinate[0] = 88;
                    coordinate[1] = 294;
                    break;
                case 58:
                    coordinate[0] = 189;
                    coordinate[1] = 335;
                    break;
                case 59:
                    coordinate[0] = 236;
                    coordinate[1] = 382;
                    break;
                case 60:
                    coordinate[0] = 306;
                    coordinate[1] = 330;
                    break;
                case 61:
                    coordinate[0] = 376;
                    coordinate[1] = 390;
                    break;
                case 62:
                    coordinate[0] = 458;
                    coordinate[1] = 356;
                    break;
                case 63:
                    coordinate[0] = 577;
                    coordinate[1] = 389;
                    break;
                case 64:
                    coordinate[0] = 647;
                    coordinate[1] = 375;
                    break;
                case 65:
                    coordinate[0] = 688;
                    coordinate[1] = 366;
                    break;
                case 66:
                    coordinate[0] = 770;
                    coordinate[1] = 384;
                    break;
                case 67:
                    coordinate[0] = 852;
                    coordinate[1] = 333;
                    break;
                case 68:
                    coordinate[0] = 955;
                    coordinate[1] = 314;
                    break;
                case 69:
                    coordinate[0] = 1005;
                    coordinate[1] = 316;
                    break;
                case 70:
                    coordinate[0] = 1115;
                    coordinate[1] = 335;
                    break;
                case 71:
                    coordinate[0] = 1230;
                    coordinate[1] = 322;
                    break;
                case 72:
                    coordinate[0] = 1365;
                    coordinate[1] = 348;
                    break;
                case 73:
                    coordinate[0] = 51;
                    coordinate[1] = 367;
                    break;
                case 74:
                    coordinate[0] = 100;
                    coordinate[1] = 420;
                    break;
                case 75:
                    coordinate[0] = 1061;
                    coordinate[1] = 289;
                    break;
                case 76:
                    coordinate[0] = 298;
                    coordinate[1] = 412;
                    break;
                case 77:
                    coordinate[0] = 339;
                    coordinate[1] = 436;
                    break;
                case 78:
                    coordinate[0] = 390;
                    coordinate[1] = 427;
                    break;
                case 79:
                    coordinate[0] = 474;
                    coordinate[1] = 409;
                    break;
                case 80:
                    coordinate[0] = 594;
                    coordinate[1] = 437;
                    break;
                case 81:
                    coordinate[0] = 661;
                    coordinate[1] = 464;
                    break;
                case 82:
                    coordinate[0] = 747;
                    coordinate[1] = 443;
                    break;
                case 83:
                    coordinate[0] = 804;
                    coordinate[1] = 417;
                    break;
                case 84:
                    coordinate[0] = 893;
                    coordinate[1] = 377;
                    break;
                case 85:
                    coordinate[0] = 959;
                    coordinate[1] = 370;
                    break;
                case 86:
                    coordinate[0] = 1023;
                    coordinate[1] = 392;
                    break;
                case 87:
                    coordinate[0] = 1164;
                    coordinate[1] = 427;
                    break;
                case 88:
                    coordinate[0] = 1185;
                    coordinate[1] = 465;
                    break;
                case 89:
                    coordinate[0] = 1256;
                    coordinate[1] = 409;
                    break;
                case 90:
                    coordinate[0] = 1291;
                    coordinate[1] = 399;
                    break;
                case 91:
                    coordinate[0] = 1428;
                    coordinate[1] = 422;
                    break;
                case 92:
                    coordinate[0] = 18;
                    coordinate[1] = 474;
                    break;
                case 93:
                    coordinate[0] = 65;
                    coordinate[1] = 530;
                    break;
                case 94:
                    coordinate[0] = 113;
                    coordinate[1] = 483;
                    break;
                case 95:
                    coordinate[0] = 190;
                    coordinate[1] = 472;
                    break;
                case 96:
                    coordinate[0] = 398;
                    coordinate[1] = 495;
                    break;
                case 97:
                    coordinate[0] = 437;
                    coordinate[1] = 486;
                    break;
                case 98:
                    coordinate[0] = 504;
                    coordinate[1] = 465;
                    break;
                case 99:
                    coordinate[0] = 571;
                    coordinate[1] = 504;
                    break;
                case 100:
                    coordinate[0] = 642;
                    coordinate[1] = 503;
                    break;
                case 101:
                    coordinate[0] = 767;
                    coordinate[1] = 500;
                    break;
                case 102:
                    coordinate[0] = 891;
                    coordinate[1] = 454;
                    break;
                case 103:
                    coordinate[0] = 973;
                    coordinate[1] = 440;
                    break;
                case 104:
                    coordinate[0] = 1023;
                    coordinate[1] = 459;
                    break;
                case 105:
                    coordinate[0] = 1291;
                    coordinate[1] = 501;
                    break;
                case 106:
                    coordinate[0] = 1364;
                    coordinate[1] = 477;
                    break;
                case 107:
                    coordinate[0] = 1416;
                    coordinate[1] = 481;
                    break;
                case 108:
                    coordinate[0] = 1266;
                    coordinate[1] = 604;
                    break;
                case 109:
                    coordinate[0] = 467;
                    coordinate[1] = 613;
                    break;
                case 110:
                    coordinate[0] = 507;
                    coordinate[1] = 530;
                    break;
                case 111:
                    coordinate[0] = 547;
                    coordinate[1] = 578;
                    break;
                case 112:
                    coordinate[0] = 614;
                    coordinate[1] = 567;
                    break;
                case 113:
                    coordinate[0] = 673;
                    coordinate[1] = 562;
                    break;
                case 114:
                    coordinate[0] = 783;
                    coordinate[1] = 542;
                    break;
                case 115:
                    coordinate[0] = 853;
                    coordinate[1] = 500;
                    break;
                case 116:
                    coordinate[0] = 1026;
                    coordinate[1] = 551;
                    break;
                case 117:
                    coordinate[0] = 1150;
                    coordinate[1] = 595;
                    break;
                case 118:
                    coordinate[0] = 1067;
                    coordinate[1] = 620;
                    break;
                case 119:
                    coordinate[0] = 1391;
                    coordinate[1] = 634;
                    break;
                case 120:
                    coordinate[0] = 21;
                    coordinate[1] = 692;
                    break;
                case 121:
                    coordinate[0] = 79;
                    coordinate[1] = 688;
                    break;
                case 122:
                    coordinate[0] = 171;
                    coordinate[1] = 719;
                    break;
                case 123:
                    coordinate[0] = 335;
                    coordinate[1] = 679;
                    break;
                case 124:
                    coordinate[0] = 420;
                    coordinate[1] = 663;
                    break;
                case 125:
                    coordinate[0] = 646;
                    coordinate[1] = 613;
                    break;
                case 126:
                    coordinate[0] = 818;
                    coordinate[1] = 603;
                    break;
                case 127:
                    coordinate[0] = 947;
                    coordinate[1] = 586;
                    break;
                case 128:
                    coordinate[0] = 1131;
                    coordinate[1] = 812;
                    break;
                case 129:
                    coordinate[0] = 1174;
                    coordinate[1] = 644;
                    break;
                case 130:
                    coordinate[0] = 616;
                    coordinate[1] = 690;
                    break;
                case 131:
                    coordinate[0] = 670;
                    coordinate[1] = 650;
                    break;
                case 132:
                    coordinate[0] = 744;
                    coordinate[1] = 640;
                    break;
                case 133:
                    coordinate[0] = 878;
                    coordinate[1] = 675;
                    break;
                case 134:
                    coordinate[0] = 985;
                    coordinate[1] = 644;
                    break;
                case 135:
                    coordinate[0] = 1218;
                    coordinate[1] = 706;
                    break;
                case 136:
                    coordinate[0] = 1387;
                    coordinate[1] = 759;
                    break;
                case 137:
                    coordinate[0] = 257;
                    coordinate[1] = 744;
                    break;
                case 138:
                    coordinate[0] = 486;
                    coordinate[1] = 709;
                    break;
                case 139:
                    coordinate[0] = 585;
                    coordinate[1] = 745;
                    break;
                case 140:
                    coordinate[0] = 775;
                    coordinate[1] = 725;
                    break;
                case 141:
                    coordinate[0] = 920;
                    coordinate[1] = 743;
                    break;
                case 142:
                    coordinate[0] = 1063;
                    coordinate[1] = 722;
                    break;
                case 143:
                    coordinate[0] = 1174;
                    coordinate[1] = 731;
                    break;
                case 144:
                    coordinate[0] = 34;
                    coordinate[1] = 829;
                    break;
                case 145:
                    coordinate[0] = 117;
                    coordinate[1] = 807;
                    break;
                case 146:
                    coordinate[0] = 157;
                    coordinate[1] = 807;
                    break;
                case 147:
                    coordinate[0] = 213;
                    coordinate[1] = 793;
                    break;
                case 148:
                    coordinate[0] = 305;
                    coordinate[1] = 819;
                    break;
                case 149:
                    coordinate[0] = 375;
                    coordinate[1] = 800;
                    break;
                case 150:
                    coordinate[0] = 410;
                    coordinate[1] = 749;
                    break;
                case 151:
                    coordinate[0] = 461;
                    coordinate[1] = 823;
                    break;
                case 152:
                    coordinate[0] = 487;
                    coordinate[1] = 758;
                    break;
                case 153:
                    coordinate[0] = 553;
                    coordinate[1] = 798;
                    break;
                case 154:
                    coordinate[0] = 657;
                    coordinate[1] = 756;
                    break;
                case 155:
                    coordinate[0] = 713;
                    coordinate[1] = 812;
                    break;
                case 156:
                    coordinate[0] = 793;
                    coordinate[1] = 850;
                    break;
                case 157:
                    coordinate[0] = 868;
                    coordinate[1] = 851;
                    break;
                case 158:
                    coordinate[0] = 984;
                    coordinate[1] = 802;
                    break;
                case 159:
                    coordinate[0] = 954;
                    coordinate[1] = 951;
                    break;
                case 160:
                    coordinate[0] = 1220;
                    coordinate[1] = 849;
                    break;
                case 161:
                    coordinate[0] = 1322;
                    coordinate[1] = 825;
                    break;
                case 162:
                    coordinate[0] = 1415;
                    coordinate[1] = 822;
                    break;
                case 163:
                    coordinate[0] = 165;
                    coordinate[1] = 880;
                    break;
                case 164:
                    coordinate[0] = 236;
                    coordinate[1] = 880;
                    break;
                case 165:
                    coordinate[0] = 391;
                    coordinate[1] = 886;
                    break;
                case 166:
                    coordinate[0] = 531;
                    coordinate[1] = 846;
                    break;
                case 167:
                    coordinate[0] = 645;
                    coordinate[1] = 866;
                    break;
                case 168:
                    coordinate[0] = 685;
                    coordinate[1] = 894;
                    break;
                case 169:
                    coordinate[0] = 756;
                    coordinate[1] = 883;
                    break;
                case 170:
                    coordinate[0] = 853;
                    coordinate[1] = 919;
                    break;
                case 171:
                    coordinate[0] = 1287;
                    coordinate[1] = 1070;
                    break;
                case 172:
                    coordinate[0] = 1093;
                    coordinate[1] = 909;
                    break;
                case 173:
                    coordinate[0] = 1247;
                    coordinate[1] = 948;
                    break;
                case 174:
                    coordinate[0] = 1350;
                    coordinate[1] = 919;
                    break;
                case 175:
                    coordinate[0] = 1421;
                    coordinate[1] = 975;
                    break;
                case 176:
                    coordinate[0] = 49;
                    coordinate[1] = 945;
                    break;
                case 177:
                    coordinate[0] = 107;
                    coordinate[1] = 928;
                    break;
                case 178:
                    coordinate[0] = 215;
                    coordinate[1] = 919;
                    break;
                case 179:
                    coordinate[0] = 338;
                    coordinate[1] = 935;
                    break;
                case 180:
                    coordinate[0] = 418;
                    coordinate[1] = 946;
                    break;
                case 181:
                    coordinate[0] = 466;
                    coordinate[1] = 898;
                    break;
                case 182:
                    coordinate[0] = 534;
                    coordinate[1] = 944;
                    break;
                case 183:
                    coordinate[0] = 587;
                    coordinate[1] = 914;
                    break;
                case 184:
                    coordinate[0] = 758;
                    coordinate[1] = 949;
                    break;
                case 185:
                    coordinate[0] = 830;
                    coordinate[1] = 1032;
                    break;
                case 186:
                    coordinate[0] = 925;
                    coordinate[1] = 1009;
                    break;
                case 187:
                    coordinate[0] = 1049;
                    coordinate[1] = 980;
                    break;
                case 188:
                    coordinate[0] = 1162;
                    coordinate[1] = 979;
                    break;
                case 189:
                    coordinate[0] = 74;
                    coordinate[1] = 1017;
                    break;
                case 190:
                    coordinate[0] = 175;
                    coordinate[1] = 1057;
                    break;
                case 191:
                    coordinate[0] = 259;
                    coordinate[1] = 998;
                    break;
                case 192:
                    coordinate[0] = 276;
                    coordinate[1] = 1090;
                    break;
                case 193:
                    coordinate[0] = 473;
                    coordinate[1] = 990;
                    break;
                case 194:
                    coordinate[0] = 486;
                    coordinate[1] = 1006;
                    break;
                case 195:
                    coordinate[0] = 547;
                    coordinate[1] = 1039;
                    break;
                case 196:
                    coordinate[0] = 645;
                    coordinate[1] = 986;
                    break;
                case 197:
                    coordinate[0] = 655;
                    coordinate[1] = 1016;
                    break;
                case 198:
                    coordinate[0] = 989;
                    coordinate[1] = 1085;
                    break;
                case 199:
                    coordinate[0] = 1209;
                    coordinate[1] = 1093;
                    break;
                
                    
            }
            return coordinate;
        }
    }
}
