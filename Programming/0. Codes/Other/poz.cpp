#include<iostream>
#include<string>
#include<stack>
#include<windows.h>

using namespace std;

int op(char ch);

int main()
{
  string niz,rez;
  stack<char>st;
  getline(cin,niz);
  int e=niz.size()-1;
  if (niz[0]=='+' || niz[0]=='-' || niz[0]=='*' || niz[0]=='/' || niz[e]=='+' || niz[e]=='-' || niz[e]=='*' || niz[e]=='/')
  {
    cout<<"Error: Nekorekten izraz"<<endl;
    exit(0);
  }
  for (int i=0;i<niz.size();i++)
  {
    if (niz[i]>='0' && niz[i]<='9')
    {
      if (niz[i+1]>='0' && niz[i+1]<='9')
        rez+=niz[i];
      else
        rez=rez+niz[i]+' ';
    }
    else if (niz[i]=='+' || niz[i]=='-' || niz[i]=='*' || niz[i]=='/')
    {
      if (niz[i+1]=='+' || niz[i+1]=='-' || niz[i+1]=='*' || niz[i+1]=='/')
      {
        cout<<"Error: Nekorekten izraz"<<endl;
        exit(0);
      }
      int on1,on2;
      if (!st.empty())
      {
        on1=op(niz[i]);
        on2=op(st.top());
        if (on1>on2) st.push(niz[i]);
        else
        {
          while (on1<=on2 && !st.empty())
          {
            rez=rez+st.top()+' ';
            st.pop();
            if (!st.empty())
            {
              on1=op(niz[i]);
              on2=op(st.top());
            }
          }
          st.push(niz[i]);
        }
      }
      else st.push(niz[i]);
    }
    else if (niz[i]=='(') st.push(niz[i]);
    else if (niz[i]==')')
    {
      while (st.top()!='(' && !st.empty())
      {
        rez=rez+st.top()+' ';
        st.pop();
        if (st.empty())
        {
          cout<<"Error: Nekorekten izraz"<<endl;
          exit(0);
        }
      }
      st.pop();
    }
  }
  while (!st.empty())
  {
    if (st.top()=='(')
    {
      cout<<"Error: Nekorekten izraz"<<endl;
      exit(0);
    }
    rez=rez+st.top()+' ';
    st.pop();
  }
  rez.erase(rez.size()-1,1);
  cout<<rez<<endl;
  //-----------------------------------------------------------------------------------
  stack<double>resh;
  string con;
  int num=0;
  for(int i=0;i<rez.size();i++)
  {

    if(rez[i]>='0' && rez[i]<='9')
      con+=rez[i];
    else
    if(rez[i]==' ')
    {
      for(int j=con.size()-1,p=1;j>=0;j--,p*=10)
        num+=(int)(con[j]-'0')*p;
      if(con.size()>0)
      resh.push(num);
      num=0;
      con.erase();
    }
    else
    if(resh.size()>1)
    {
    double on1,on2;

      on2=resh.top();
      resh.pop();
      on1=resh.top();
      resh.pop();
    if(rez[i]=='+')
      resh.push(on1+on2);
    else if(rez[i]=='-')
      resh.push(on1-on2);
    else if(rez[i]=='*')
      resh.push(on1*on2);
    else if(rez[i]=='/')
      resh.push(on1/on2);
    else
    {
      resh.push(on1);
      resh.push(on2);
    }
    }
  }
  cout<<resh.top();
}

int op(char ch)
{
  switch (ch)
  {
  case '+':
    return 1;
  case '-':
    return 1;
  case '*':
    return 2;
  case '/':
    return 3;
  default:
    return 0;
  }
}

//(14+22+355)/41-500*786*72
//9-3*4-2*5
