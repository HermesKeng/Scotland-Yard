//
//  main.cpp
//  Adjacent_list
//
//  Created by 耿楷寗 on 2/4/17.
//  Copyright © 2017 耿楷寗. All rights reserved.
//

#include <iostream>
#include <list>
#include <fstream>
#include<sstream>
#include <string>
using namespace std;

struct Node{
    int vertex_num;
    int list_sum;
    list<int> Road_connected_list;
    list<int> Train_connected_list;
    list<int> Bus_connected_list;
};
//each vertex is a node array.
//In the node struct,we use container list<int> includes each point that connects the vertex
//void insert_node(int index):this function is for insert the list which is in the node array
//void search_Road_connect_point(int index):this function is used to search the connected point by inputting our index
class Game_map{
    private:
        Node *vertex;
        int vertex_Sum;
    public:
        Game_map(int sum){
            this->vertex_Sum=sum;
            vertex=new Node[vertex_Sum+1];
        }
        void insert_node(int index,int point){
                this->vertex[index].Road_connected_list.push_back(point);
        };
        void search_Road_connect_point(int index){
            
            list<int>:: iterator it;
            if(this->vertex[index].Road_connected_list.size()==0){
                cout<<index<<" doesn't connect any point !"<<endl;
            }else{
                cout<<index<<" conneted point : ";
                for(it=this->vertex[index].Road_connected_list.begin();it!=this->vertex[index].Road_connected_list.end();it++){
                    cout<<*it<<" ";
                }
				cout<<endl;
            }
        }

};
int main(int argc, const char * argv[]) {
    
    Game_map test(199);
	istringstream iss;
	string temp_str;
	fstream fs;
	int connet_point;
	int vertex;
	//use read/write file to build the map
	//in the map.txt,we have each vertex and where the vertex connected
	fs.open("/Users/keng/Desktop/Adjacent_list/Adjacent_list/map.txt",fstream::in);
	
	if(!fs.is_open()){
		cout<<"file is not opened"<<endl;
	}else{
		
		for(int i=1;i<=199;i++){
			getline(fs,temp_str);
			//use iss->iss likes buffer can transform string temp_str to a stream_buf
			//we only use iss>>vertex to get each vertex
			iss.str(temp_str);
			iss>>vertex;
			//if buffer.eof() is false, it means that vertex still has the point connecting to it
			while(!iss.eof()){
				iss>>connet_point;
				test.insert_node(vertex, connet_point);
			}
			iss.clear();
		}
	}
	for(int i=1;i<=199;i++){
		test.search_Road_connect_point(i);
	}

    return 0;
}
