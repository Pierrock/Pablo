/*
 
 Projet Digital 24 x input  et 24 x output
 Language: Wiring/Arduino
 
 Created   10/01/2017   by Pierre Faucher
 modified  15/01/2017   by 

ON_x  -> sélection du relais x

 */

String inputString = "";      // La chaine de commande reçue
char inChar;                  //  1 caractère reçu

void setup()
{
  //  24 sorties pour relais

  pinMode(27, OUTPUT);  //  Relais 1  
  pinMode(28, OUTPUT);  //  Relais 2  
  pinMode(29, OUTPUT);  //  Relais 3
  pinMode(30, OUTPUT);  //  Relais 4
  pinMode(31, OUTPUT);  //  Relais 5
  pinMode(32, OUTPUT);  //  Relais 6
  pinMode(33, OUTPUT);  //  Relais 7
  pinMode(34, OUTPUT);  //  Relais 8
  pinMode(35, OUTPUT);  //  Relais 9
  pinMode(36, OUTPUT);  //  Relais 10
  pinMode(37, OUTPUT);  //  Relais 11
  pinMode(38, OUTPUT);  //  Relais 12
  pinMode(39, OUTPUT);  //  Relais 13
  pinMode(40, OUTPUT);  //  Relais 14
  pinMode(41, OUTPUT);  //  Relais 15
  pinMode(42, OUTPUT);  //  Relais 16
  pinMode(43, OUTPUT);  //  Relais 17
  pinMode(44, OUTPUT);  //  Relais 18
  pinMode(45, OUTPUT);  //  Relais 19
  pinMode(46, OUTPUT);  //  Relais 20
  pinMode(47, OUTPUT);  //  NON CONNECTE
  pinMode(48, OUTPUT);  //  Relais 21
  pinMode(49, OUTPUT);  //  NON CONNECTE
  pinMode(50, OUTPUT);  //  Relais 22
  pinMode(51, OUTPUT);  //  Relais 23
  pinMode(52, OUTPUT);  //  Relais 24
      
  //  init des 24 relais
  for (int relais = 27; relais <= 52; relais++)
    {
      digitalWrite(relais, LOW);      // commande relais OFF
    }


  //  24 entrées
  pinMode(2, INPUT);  //  Entree 1
  pinMode(3, INPUT);  //  Entree 2
  pinMode(4, INPUT);  //  Entree 3
  pinMode(5, INPUT);  //  Entree 4
  pinMode(6, INPUT);  //  Entree 5
  pinMode(7, INPUT);  //  Entree 6  
  pinMode(8, INPUT);  //  NON CONNECTE
  pinMode(9, INPUT);  //  Entree 7 
  pinMode(10, INPUT);  //  Entree 8 
  pinMode(11, INPUT);  //  Entree 9 
  pinMode(12, INPUT);  //  Entree 10 
  pinMode(13, INPUT);  //  Entree 11 
  pinMode(14, INPUT);  //  Entree 12 
  pinMode(15, INPUT);  //  Entree 13 
  pinMode(16, INPUT);  //  Entree 14 
  pinMode(17, INPUT);  //  Entree 15 
  pinMode(18, INPUT);  //  Entree 16 
  pinMode(19, INPUT);  //  Entree 17 
  pinMode(20, INPUT);  //  Entree 18 
  pinMode(21, INPUT);  //  Entree 19 
  pinMode(22, INPUT);  //  Entree 20 
  pinMode(23, INPUT);  //  Entree 21 
  pinMode(24, INPUT);  //  Entree 22
  pinMode(25, INPUT);  //  Entree 23
  pinMode(26, INPUT);  //  Entree 24
  
  // start serial port at 9600 bps:
  Serial.begin(9600);
  while (!Serial) 
  {
    ; // wait for serial port to connect. Needed for Leonardo only
  }

  //establishContact();  // send a byte to establish contact until receiver responds 
}



bool PiloteRelais(String chaine)
  {
    bool OnOff = false;
  
    //  Commande "ON" ou "OFF"
    if (chaine.startsWith("ON") )
      {
        //  Relais ON
            OnOff = true;
      } 
    else if (chaine.startsWith("OFF") )
      {
        //  relais OFF
            OnOff = false; 
      }
    else
      {
      //  ce n'est pas une commande valide
          return false;
      }
 
    int separateur = chaine.indexOf('_');
    if ( separateur < 1 )
    {
      //Serial.println("!separateur");
      
      //  ce n'est pas une commande valide
      return false;
    }
  
    String srelais = inputString.substring(separateur+1); // le numéro du relais (string)
    int irelais = srelais.toInt();
  
    if (irelais < 1)  { irelais = 1;  }
    if (irelais > 24) { irelais = 24; }

    switch (irelais) 
    {
    case 1: digitalWrite(52, OnOff);   break;
    case 2: digitalWrite(51, OnOff);   break;
    case 3: digitalWrite(50, OnOff);   break;
    case 4: digitalWrite(48, OnOff);   break;
    case 5: digitalWrite(46, OnOff);   break;
    case 6: digitalWrite(45, OnOff);   break;
    case 7: digitalWrite(44, OnOff);   break;
    case 8: digitalWrite(43, OnOff);   break;
    case 9: digitalWrite(42, OnOff);   break;
    case 10: digitalWrite(41, OnOff);   break;
    case 11: digitalWrite(40, OnOff);   break;
    case 12: digitalWrite(39, OnOff);   break;
    case 13: digitalWrite(38, OnOff);   break;
    case 14: digitalWrite(37, OnOff);   break;
    case 15: digitalWrite(36, OnOff);   break;
    case 16: digitalWrite(35, OnOff);   break;
    case 17: digitalWrite(34, OnOff);   break;
    case 18: digitalWrite(33, OnOff);   break;
    case 19: digitalWrite(32, OnOff);   break;
    case 20: digitalWrite(31, OnOff);   break;
    case 21: digitalWrite(30, OnOff);   break;
    case 22: digitalWrite(29, OnOff);   break;
    case 23: digitalWrite(28, OnOff);   break;
    case 24: digitalWrite(27, OnOff);   break;
    default:
      // if nothing else matches, do the default
      // default is optional
    break;
  }
 
    return true;
  }


bool GetInputs(String chaine)
{
    //  Commande "GET"
    if (!chaine.startsWith("GET") )
      {
        //  ce n'est pas une commande valide
            return false;
      } 

    int val = 0;     //


    //val = digitalRead(5);   // read the input pin
    //Serial.print( String(val)  );
    //Serial.print(";");


    
    // de 3 à 7
    for (int i = 3; i <= 7; i++)
      {
          val = digitalRead(i);   // read the input pin
          Serial.print( String(val)  );
          Serial.print(";");
      }

    // l'entrée 8 n'est pas connectée
    // remplacée par 2
    val = digitalRead(2);   // read the input pin
    Serial.print( String(val)  );
    Serial.print(";");


    
    // de 9 à 26
    for (int i = 9; i <= 26; i++)
      {
          val = digitalRead(i);   // read the input pin
          Serial.print( String(val)  );
          Serial.print(";");
      }
    Serial.println();
      
  return true;
}

bool Reset(String chaine)
  {
    //  Commande "RESET"
    if (!chaine.startsWith("RESET") )
      {
        //  ce n'est pas une commande valide
            return false;
      }     

    for (int i = 27; i <= 52; i++)
      {
        //  Commande du relais
            digitalWrite(i, LOW);     // OFF
      }

    return true;  
  } 


bool GetInfo(String chaine)
  {
    //  Commande "INFO"
    if (!chaine.startsWith("INFO") )
      {
        //  ce n'est pas une commande valide
            return false;
      }     
    Serial.println("DIO48");

    return true;
  }


void loop()
{

  // if we get a valid byte, read analog ins:
  if (Serial.available() > 0) 
  {

    // lecture du caractère reçu
    inChar = (char)Serial.read(); 
    
    if (inChar == 13) 
    {
        //  Retour chariot = commande complète
        //  Serial.println(inputString);

            if (GetInputs(inputString))
            {
              //  accusé reception
                  //Serial.print(inputString);
                  //Serial.println(" OK");
            }
            else if (PiloteRelais(inputString))
            {
              //  accusé reception
                  //Serial.print(inputString);
                  //Serial.println(" OK");
            }
            else if (Reset(inputString))
            {
              //  accusé reception
                  //Serial.print(inputString);
                  //Serial.println(" OK");
            }
            else if (GetInfo(inputString))
            {
              //  accusé reception
                  //Serial.print(inputString);
                  //Serial.println(" OK");
            }
            else 
            {
              //  accusé reception
                  Serial.print(inputString);
                  Serial.println(" KO");              
            }

        //  Vidange de la chaine de commande
            inputString = "" ;
    }
    else
    {
        // ajoute le caractère
          inputString += inChar;    
    }
  }
}

void establishContact() {
  while (Serial.available() <= 0) {
    Serial.print('A');   // send a capital A
    delay(300);
  }
}


