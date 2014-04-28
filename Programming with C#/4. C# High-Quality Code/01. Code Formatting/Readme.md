## Code Formatting

1. Format correctly the following source code:

    ```c#
    using System;
    using System.Collections.Generic;


    using System.Linq; using System.Text;
    using Wintellect.PowerCollections;

    class Event:IComparable
    {
      public DateTime    date;
        public String      title;
        public String      location;

        public Event( DateTime date , String title , String location ) {
            this.date = date;

            this.title = title;
                this.location = location;
        }

        public int  CompareTo(object obj)
        {
            Event other    = obj as                 Event;
            int byDate     = this.date. CompareTo   (other.date);
            int byTitle    = this.title.CompareTo   (other.title);

            int byLocation = this.location.CompareTo(other.location);
            if (byDate == 0)
            {
                if( byTitle==0 )
                    return byLocation;
                else
                    { return byTitle; }


            }
            else
                return byDate;
        }

        public override string ToString ( )
        {
            StringBuilder toString=new StringBuilder ();
            toString.Append( date
                .ToString("yyyy-MM-ddTHH:mm:ss") );


            toString.Append(" | "+title);
            if (location != null && location != "") toString.Append(" | " + location);
                return toString.ToString();
        }
    }

    class Program
    {


        static StringBuilder output = new StringBuilder();

        static class Messages
        {
            public static void EventAdded()
            { output.Append("Event added\n"); }
            public static void EventDeleted(int x)
            {
                if ( x == 0 ) NoEventsFound();

                else output.AppendFormat("{0} events deleted\n",x);
            }
            public static void NoEventsFound() { output.Append( "No events found\n" ); }
            public static void PrintEvent ( Event eventToPrint ) {


                if( eventToPrint!=null ) {
                    output.Append( eventToPrint+"\n");
                }
            }
        }

        class EventHolder
        {
            MultiDictionary<string, Event>
                byTitle = new MultiDictionary<string,
                Event>(true);
            OrderedBag<Event>
                byDate = new OrderedBag<
                Event>();

            public void AddEvent(DateTime date,
                                 string title,
                                 string location)
            {
                Event newEvent = new Event(date,
                                           title,
                                           location);
                byTitle.Add(
                            title.ToLower(),
                            newEvent
                            );
                byDate.Add(newEvent);   Messages.EventAdded();
            }

            public void DeleteEvents(string titleToDelete)
            {
                string title = titleToDelete
                        .ToLower();
                int removed = 0;
                foreach ( var eventToRemove in byTitle [ title ] ) {
                    removed ++;
                    byDate.Remove ( eventToRemove );
                }
                byTitle.Remove (title);
                Messages.EventDeleted( removed );
            }
            public void ListEvents(DateTime date, int count)
            {
                OrderedBag<Event>.View
                        eventsToShow = byDate.RangeFrom(new Event(
                        date, "", ""),
                        true);
                int showed = 0;
                foreach (var eventToShow in eventsToShow)
                {
                    if (showed == count) break;
                    Messages.PrintEvent(eventToShow);

                    showed++;
                }
                if (showed == 0) Messages.NoEventsFound();
            }
        } static EventHolder events = new EventHolder();

        static void Main(string[] args) {
            while (ExecuteNextCommand()) { }
            Console.WriteLine(output);
        }

        private static bool ExecuteNextCommand()
        {
            string command = Console.ReadLine();
            if(command[0]=='A'){AddEvent(command);return true;}
            if(command[0]=='D'){DeleteEvents(command);return true;}


            if(command[0]=='L'){ListEvents(command);return true;}
            if(command[0]=='E'){return false;}
            return false;
        }

        private static void ListEvents(string command)

        {
            int pipeIndex = command.IndexOf('|')
            ;
            DateTime date = GetDate(
            command,
            "ListEvents");
            string countString = command.Substring(
                pipeIndex + 1
            );


            int count = int.Parse(countString);
            events.ListEvents(date,
            count);
        }

        private static void


            DeleteEvents( string command )
        {
            string title = command.Substring
            (
                "DeleteEvents".Length + 1
            );
            events.DeleteEvents(title);
        }

        private static void AddEvent(string command)
        {
            DateTime date; string title; string location;
            GetParameters(command, "AddEvent",
                    out date, out title, out location);

            events.AddEvent
                    (date, title, location);
        }
        private static void GetParameters(string commandForExecution, string commandType, out DateTime dateAndTime, out string eventTitle, out string eventLocation)
        {
            dateAndTime = GetDate(commandForExecution, commandType);
            int firstPipeIndex = commandForExecution.IndexOf('|');


            int lastPipeIndex = commandForExecution.LastIndexOf('|');
            if (  firstPipeIndex == lastPipeIndex  ){ eventTitle =
                    commandForExecution.Substring(firstPipeIndex
                    + 1).Trim();
                eventLocation = "";
            }
            else {
                eventTitle = commandForExecution.Substring(
                                                        firstPipeIndex + 1,
                                                        lastPipeIndex - firstPipeIndex - 1)
                                                    .Trim();
                eventLocation = commandForExecution.Substring(lastPipeIndex + 1).Trim(); }
        }
        private
        static
        DateTime
        GetDate(

        string command,
        string commandType
        )
        {
            DateTime date = DateTime.Parse(command
                .Substring(commandType.Length +

                1, 20));
            return date;
        }
    }
    ```
* Format correctly the following source code:

    ```js
    b=navigator.appName
addScroll=false;if ((navigator.userAgent.indexOf('MSIE 5')>0) || (navigator.userAgent.indexOf('MSIE 6'))>0) {addScroll = true;}
var off=0;var txt="";var pX=0;var pY=0;document.onmousemove = mouseMove; if (b == "Netscape") {document.captureEvents(Event.MOUSEMOVE)};
function mouseMove(evn)  { if (b == "Netscape")   { pX=evn.pageX-5; pY=evn.pageY;   }else   {   pX=event.x-5;   pY=event.y; }if (b == "Netscape")   {   if (document.layers['ToolTip'].visibility=='show') {PopTip();}
    }else   {   if (document.all['ToolTip'].style.visibility=='visible') {PopTip();}
    }}function PopTip(){if (b == "Netscape")    {   theLayer = eval('document.layers[\'ToolTip\']');        if ((pX+120)>window.innerWidth)
        {   pX=window.innerWidth-150;       }   theLayer.left=pX+10;    theLayer.top=pY+15; theLayer.visibility='show';
    } else  {   theLayer = eval('document.all[\'ToolTip\']');
    if (theLayer)   {       pX=event.x-5;       pY=event.y;     if (addScroll)                  {           pX=pX+document.body.scrollLeft;
            pY=pY+document.body.scrollTop;          }       if ((pX+120)>document.body.clientWidth)
            {           pX=pX-150;          }       theLayer.style.pixelLeft=pX+10;
        theLayer.style.pixelTop=pY+15;      theLayer.style.visibility='visible';
        }   }}function HideTip() {  args=HideTip.arguments;
    if (b == "Netscape")        { document.layers['ToolTip'].visibility='hide'; }
    else        { document.all['ToolTip'].style.visibility='hidden'; }
}function HideMenu1() { if (b == "Netscape")        { document.layers['menu1'].visibility='hide'; }     else        { document.all['menu1'].style.visibility='hidden'; }}
function ShowMenu1(){if (b == "Netscape")    {    theLayer = eval('document.layers[\'menu1\']');        theLayer.visibility='show';    } else {    theLayer = eval('document.all[\'menu1\']');    theLayer.style.visibility='visible';   }}//
function HideMenu2()            {        if (b == "Netscape")       { document.layers['menu2'].visibility='hide'; } else
        { document.all['menu2'].style.visibility='hidden'; } } function ShowMenu2(){if (b == "Netscape")    {    theLayer = eval('document.layers[\'menu2\']');     theLayer.visibility='show';    } else {    theLayer = eval('document.all[\'menu2\']');    theLayer.style.visibility='visible';   }} // fostata
    ```
