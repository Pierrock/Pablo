//  Odometre pour Pablo
//  Voir le fichier Odemetre_ArduinoMicro1.png


int MOTG_INT = 2;   //  interrupt sur digital 0 = INT 2
int MOTG_PHA = 0;   //  input digital 0
int MOTG_PHB = 1;   //  input digital 1
int MOTG_VALA ;
int MOTG_VALA_old ;
int MOTG_VALB ;
volatile int MOTG_COUNT;
int MOTG_COUNT_OLD;


int MOTD_INT = 1; // interrupt sur digital 3 = INT 1
int MOTD_PHA = 3; //  input digital 3
int MOTD_PHB = 2; //  input digital 2
int MOTD_VALA ;
int MOTD_VALA_old ;
int MOTD_VALB ;
volatile int MOTD_COUNT;
int MOTD_COUNT_OLD;


String inputString = "";      // La chaine de commande reçue
char inChar;                  //  1 caractère reçu
boolean commande_ok = false;  //
boolean _odo_run = false;




void setup() {
  attachInterrupt(MOTG_INT, interrupt_MotG_phA, RISING );
  pinMode(MOTG_PHA, INPUT);
  pinMode(MOTG_PHB, INPUT);

  attachInterrupt(MOTD_INT, interrupt_MotD_phA, RISING );
  pinMode(MOTD_PHA, INPUT);
  pinMode(MOTD_PHB, INPUT);  
}

//  interruption Moteur Gauche
void interrupt_MotG_phA() 
{
  if (!_odo_run) return;
  
  MOTG_VALA = digitalRead(MOTG_PHA);
  MOTG_VALB = digitalRead(MOTG_PHB);

  if ( MOTG_VALA != MOTG_VALA_old)
  {
    //  modification du signal sur l'entrée MOTG_PHA
  if (MOTG_VALA==1)
    {
      // signal sur l'entrée MOTG_PHA = 1
      if (MOTG_VALB==0)
        {
          MOTG_COUNT++;
        }
      else
        {
          MOTG_COUNT--;
        }
    }
    else
    {
      // signal sur l'entrée MOTG_PHA = 0
      if (MOTG_VALB==0)
        {
          MOTG_COUNT--;
        }
      else
        {
          MOTG_COUNT++;
        }      
     
    }
    MOTG_VALA_old = MOTG_VALA;
  }
  delay(1);
}

//  interruption Moteur Droite
void interrupt_MotD_phA() 
{
   if (!_odo_run) return;
  
  MOTD_VALA = digitalRead(MOTD_PHA);
  MOTD_VALB = digitalRead(MOTD_PHB);

  if ( MOTD_VALA != MOTD_VALA_old)
  {
    //  modification du signal sur l'entrée MOTD_PHA
  if (MOTD_VALA==1)
    {
      // signal sur l'entrée MOTD_PHA = 1
      if (MOTD_VALB==0)
        {
          MOTD_COUNT++;
        }
      else
        {
          MOTD_COUNT--;
        }
    }
    else
    {
      // signal sur l'entrée MOTD_PHA = 0
      if (MOTD_VALB==0)
        {
          MOTD_COUNT--;
        }
      else
        {
          MOTD_COUNT++;
        }      
     
    }
    MOTD_VALA_old = MOTD_VALA;
  }
  delay(1); 
}



void loop() 
{
  //  réception d'une commande ?
  if (Serial.available() > 0) 
  {
 // lecture du caractère reçu
    inChar = (char)Serial.read(); 
    
    if (inChar == 13) 
    {
      //  Retour chariot = commande complète
 
          if (inputString == "ODO_start")
          {
            //  La commande est reconnue
                commande_ok = true ;
            //  accusé reception
                Serial.print(inputString);
                Serial.println(" OK");

                _odo_run = true;
          }      

          if (inputString == "ODO_reset")
          {
            //  La commande est reconnue
                commande_ok = true ;

                MOTG_COUNT = 0;
                MOTG_COUNT_OLD = 0;
                MOTD_COUNT = 0;
                MOTD_COUNT_OLD = 0;
				
				        Serial.print(MOTG_COUNT, DEC);
				        Serial.print(" ");
				        Serial.print(MOTD_COUNT, DEC);
				        Serial.println();				
				
          }      

          if (inputString == "ODO_stop")
          {
            //  La commande est reconnue
                commande_ok = true ;
                     
            //  accusé reception
               Serial.print(inputString);
               Serial.println(" OK");

               _odo_run = false;
           }      




      //  Si la commande n'est pas reconnue
          if (commande_ok != true)
          {
              Serial.print(inputString);
              Serial.println(" KO");
          }

      //  prêt à recevoir une nouvelle commande
          commande_ok = false;
      
      //  Vidange de la chaine de commande
          inputString = "" ;
    }
    else
    {
      // ajoute le caractère
        inputString += inChar;    
    }
  }
  
  if((MOTG_COUNT_OLD!=MOTG_COUNT) || (MOTD_COUNT_OLD!=MOTD_COUNT))
  {
    Serial.print(MOTG_COUNT, DEC);
    Serial.print(" ");
    Serial.print(MOTD_COUNT, DEC);
    Serial.println();
    if(MOTG_COUNT_OLD!=MOTG_COUNT) MOTG_COUNT_OLD=MOTG_COUNT;
    if(MOTD_COUNT_OLD!=MOTD_COUNT) MOTD_COUNT_OLD=MOTD_COUNT;
  }
  delay(20);
}
