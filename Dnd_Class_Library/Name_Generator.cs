﻿using System;

namespace Dnd_Class_Library
{
    public class Name_Generator
    {
        string[,] NAME_PARTS = new string[101,3]
        {
            { "A", "bb", "a" },{"Ada","bl","ab"},{"Aki","bold","ac"},{"Al","br","ace"},
            {"Ali","bran","ach"},{"Alo","can","ad"},{"Ana","carr","adle"},{"Ani","ch","af"},
            {"Ba","cinn","ag"},{"Be","ck","ah"},{"Bo","ckl","ai"},{"Bra","ckr","ak"},
            {"Bro","cks","aker"},{"Cha","dd","al"},{"Chi","dell","ale"},{"Da","dr","am"},
            {"De","ds","an"},{"Do","fadd","and"},{"Dra","fall","ane"},{"Dro","farr","ar"},
            {"Eki","ff","ard"},{"Eko","fill","ark"},{"Ele","fl","art"},{"Eli","fr","ash"},
            {"Elo","genn","at"},{"Er","gg","ath"},{"Ere","gl","ave"},{"Eri","gord","ea"},
            {"Ero","gr","eb"},{"Fa","gs","ec"},{"Fe","h","ech"},{"Fi","hall","ed"},
            {"Fo","hark","ef"},{"Fra","hill","eh"},{"Gla","hork","ek"},{"Gro","jenn","el"},
            {"Ha","kell","elle"},{"He","kill","elton"},{"Hi","kk","em"},{"Illia","kl","en"},
            {"Ira","klip","end"},{"Ja","kr","ent"},{"Jo","krack","enton"},{"Ka","ladd","ep"},
            {"Kel","lah","eq"},
            {"Ki","land","er"},{"Kra","lark","esh"},{"La","ld","ess"},{"Le","ldr","ett"},
            {"Lo","lind","ic"},{"Ma","ll","ich"},{"Me","ln","id"},{"Mi","lord","if"},
            {"Mo","ls","ik"},{"Na","matt","il"},{"Ne","mend","im"},{"No","mm","in"},
            {"O","ms","ion"},{"Ol","nd","ir"},{"Or","nett","is"},{"Pa","ng","ish"},
            {"Pe","nk","it"},{"Pi","nn","ith"},{"Po","nodd","ive"},{"Pra","ns","ob"},
            {"Qua","nt","och"},{"Qui","part","od"},{"Quo","pelt","odin"},{"Ra","pl","oe"},
            {"Re","pp","of"},{"Ro","ppr","oh"},{"Sa","pps","ol"},{"Sca","rand","olen"},
            {"Sco","rd","omir"},{"Se","resh","or"},{"Sha","rn","orb"},{"She","rp","org"},
            {"Sho","rr","ort"},{"So","rush","os"},{"Sta","salk","osh"},{"Ste","sass","ot"},
            {"Sti","sc","oth"},{"Stu","sh","ottle"},{"Ta","sp","ove"},{"Tha","ss","ow"},
            {"The","st","ox"},{"Tho","tall","ud"},{"Ti","tend","ule"},{"To","told","umber"},
            {"Tra","v","un"},{"Tri","vall","under"},{"Tru","w","undle"},{"Ul","wall","unt"},
            {"Ur","wild","ur"},{"Va","will","us"},{"Vo","x","ust"},{"Wra","y","ut"},
            {"Xa","yang",""},{"Xi","yell",""},{"Zha","z",""},{"Zho","zenn",""},
        };
        public string generateName()
        {
            string theName = "";
            Random rand = new Random();
            int num1 = rand.Next(0, 100);
            int num2 = rand.Next(0, 100);
            int num3 = rand.Next(0, 100);
            theName =
                NAME_PARTS[num1, 0] + NAME_PARTS[num2, 1] + NAME_PARTS[num3, 2];
            return theName;
        }
    }
}
