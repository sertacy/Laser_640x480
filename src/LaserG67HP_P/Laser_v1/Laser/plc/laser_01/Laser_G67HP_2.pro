CoDeSys+6   �                   @        @   2.3.8.0    @/    @                             NG A   C:\TwinCAT\Plc\Upload\ @                           �f/F   |C:\TwinCAT\Plc\Upload\VisuBmp\   C:\TwinCAT\Plc\Upload\PLCCONF\�    @      C:\TWINCAT\PLC\LIB\STANDARD.LIB          CONCAT               STR1               ��              STR2               ��                 CONCAT                                         ��66  �   ����           CTD           M             ��           Variable for CD Edge Detection      CD            ��           Count Down on rising edge    LOAD            ��           Load Start Value    PV           ��           Start Value       Q            ��           Counter reached 0    CV           ��           Current Counter Value             ��66  �   ����           CTU           M             ��            Variable for CU Edge Detection       CU            ��       
    Count Up    RESET            ��           Reset Counter to 0    PV           ��           Counter Limit       Q            ��           Counter reached the Limit    CV           ��           Current Counter Value             ��66  �   ����           CTUD           MU             ��            Variable for CU Edge Detection    MD             ��            Variable for CD Edge Detection       CU            ��	       
    Count Up    CD            ��
           Count Down    RESET            ��           Reset Counter to Null    LOAD            ��           Load Start Value    PV           ��           Start Value / Counter Limit       QU            ��           Counter reached Limit    QD            ��           Counter reached Null    CV           ��           Current Counter Value             ��66  �   ����           DELETE               STR               ��              LEN           ��              POS           ��                 DELETE                                         ��66  �   ����           F_TRIG           M             ��
                 CLK            ��           Signal to detect       Q            ��           Edge detected             ��66  �   ����           FIND               STR1               ��              STR2               ��                 FIND                                     ��66  �   ����           INSERT               STR1               ��              STR2               ��              POS           ��                 INSERT                                         ��66  �   ����           LEFT               STR               ��              SIZE           ��                 LEFT                                         ��66  �   ����           LEN               STR               ��                 LEN                                     ��66  �   ����           MID               STR               ��              LEN           ��              POS           ��                 MID                                         ��66  �   ����           R_TRIG           M             ��
                 CLK            ��           Signal to detect       Q            ��           Edge detected             ��66  �   ����           REPLACE               STR1               ��              STR2               ��              L           ��              P           ��                 REPLACE                                         ��66  �   ����           RIGHT               STR               ��              SIZE           ��                 RIGHT                                         ��66  �   ����           RS               SET            ��              RESET1            ��                 Q1            ��
                       ��66  �   ����           SEMA           X             ��                 CLAIM            ��	              RELEASE            ��
                 BUSY            ��                       ��66  �   ����           SR               SET1            ��              RESET            ��                 Q1            ��	                       ��66  �   ����           TOF           M             ��           internal variable 	   StartTime            ��           internal variable       IN            ��       ?    starts timer with falling edge, resets timer with rising edge    PT           ��           time to pass, before Q is set       Q            ��	       2    is FALSE, PT seconds after IN had a falling edge    ET           ��
           elapsed time             ��66  �   ����           TON           M             ��           internal variable 	   StartTime            ��           internal variable       IN            ��       ?    starts timer with rising edge, resets timer with falling edge    PT           ��           time to pass, before Q is set       Q            ��	       0    is TRUE, PT seconds after IN had a rising edge    ET           ��
           elapsed time             ��66  �   ����           TP        	   StartTime            ��           internal variable       IN            ��       !    Trigger for Start of the Signal    PT           ��       '    The length of the High-Signal in 10ms       Q            ��	           The pulse    ET           ��
       &    The current phase of the High-Signal             ��66  �   ����                  ASMSOLLW               Auto                           Stufe                          Hand             	                 Sollw                                   4e�F  @    ����           BETRIEBSARTEN                             4e�F  @    ����           INDEXSTEUERNUNG           SR1                 RS    1               PF_1                 R_TRIG    1               PF2                 R_TRIG    1 	              PF_3                 R_TRIG    1 
                               4e�F  @    ����           INIT                             4e�F  @    ����           KETTENSPEICHER                   KSenableInput            
               KSenableOutput            
                        4e�F  @    ����           KETTENTYPEN                             4e�F  @    ����           MAIN_1           SollPos1                    SollPos                   Stufe1                        	   ASMSollW1                  AsmSollW                   Poserreicht                            Motorsteuerung1                    Motorsteuerun                   Betriebsarten1               Betriebsarten                   Kettenspeicher1                Kettenspeicher     	              KSEnIn              
              KSEnOut                            Saugersteuerung1               Saugersteuerung                   Kettentypen1               Kettentypen                                    4e�F  @    ����           MAIN_2                             4e�F  @    ����           MOTORSTEUERUN           PF_AutoStart                 R_TRIG     
              PF_AutoStop                 R_TRIG                	   StopGoMot                 RS                      Poserreicht                           KSenableInput                           KSEnableOutput                                        4e�F  @    ����           NOCKENSCHALTWERK           Zeiger                           Nocke                            Zaeler                       Skal_IC_SSI_DG_Input: DINT;   Skal_IC_SSI_DG_Input_Alt                           Skal_IC_SSI_DG_Input_Delta                           Skal_SSI_DG_4_Alt             	           
   ImpulsPos4              
                               4e�F  @    ����           SAUGERSTEUERUNG                             4e�F  @    ����           SOLLPOS           ZeigerStufe1             	              ZeigerStufe2             
              ZeigerStufe3                           ZeigerStufe4                           ZeigerStufe5                                  Stufe                                   4e�F  @    ����            
 n      5         ( �!      K   �!     K   �!     K   �!     K   "                 "         +     ��localhost       �¿w   �A     �       ��    ��      � �\�wp �w�����¿w>�3     �� �A        @����A     x.bP� H.b\�        H.b   P.b�!���   ��    �� t� X� �|��|������|�� �A        �� �A     ��� ��E���� � ��� ��E����,� =��     ,   ,                                                        K         @   4e�F�#  /*BECKCONFI3*/
        !�� @   @   �   �     3                 Standard     P   Panel            	 NG                        VAR_GLOBAL
END_VAR
                                                                                  "   , , : ��             Standard        	MAIN_1();����                PanelP        	MAIN_2();����               4e�F                 $����                         x*�)0+�+           Standard �f/F	�f/F      �788p8�9                         	4e�F                        VAR_CONFIG
END_VAR
                                                                                   '              ,  � �1           Globale_Variablen 4e�F	 NG     ����           �  VAR_GLOBAL

	(* Hardwareeing�nge *)
	INot_Aus 			 	AT %IX0.0 : BOOL; (* Eingang 1 *)
	IDruckW			  	AT %IX0.1 : BOOL; (* Eingang 2 *)
	ISchututuer	  		AT %IX0.2 : BOOL; (* Eingang 3 *)
	ISchutzhaube  		AT %IX0.3 : BOOL; (* Eingang 4 *)
	IHWT_EIN			 	AT %IX0.4 : BOOL; (* Eingang 5 *)
	IHWT_AUS			AT %IX0.5 : BOOL; (* Eingang 6 *)
	IHWT_Quitt  			AT %IX0.6 : BOOL; (* Eingang 7 *)
	IRES1					AT %IX0.7 : BOOL; (* Eingang 8 *)

       IINI_Ueberlast  		AT %IX1.0 : BOOL; (* Eingang 9 *)
	IINI_IndexVor	  		AT %IX1.1 : BOOL; (* Eingang 10 *)
	IINI_IndexRueck  		AT %IX1.2 : BOOL; (* Eingang 11 *)
	IINI_Kupplung  		AT %IX1.3 : BOOL; (* Eingang 12 *)
	IRES2			  		AT %IX1.4 : BOOL; (* Eingang 13 *)
	IRES3		 			AT %IX1.5 : BOOL; (* Eingang 14 *)
	IRES4					AT %IX1.6 : BOOL;
	IRES5		 			AT %IX1.7 : BOOL;

	IKammError  			AT %IX2.0 : BOOL; (* Eingang 17 *)
	IKammEnable  		AT %IX2.1 : BOOL; (* Eingang 18 *)
	IKammOutput  		AT %IX2.2 : BOOL; (* Eingang 19 *)
	IRES6		 			AT %IX2.3 : BOOL; (* Eingang 20 *)
	IAbsaug100P 			AT %IX2.4 : BOOL; (* Eingang 21 *)
	IAbsaugFilter			AT %IX2.5 : BOOL; (* Eingang 22 *)
	IRES					AT %IX2.6 : BOOL; (* Eingang 23 *)
	IFU_BB				AT %IX2.7 : BOOL; (* Eingang 24 *)

	IFrgMoma1 			AT %IX3.0 : BOOL;
	IFrgMoma2 			AT %IX3.1 : BOOL;
	IRES7	 				AT %IX3.2 : BOOL;
	IRES8	 				AT %IX3.3 : BOOL;
	ILAS_HWIO 			AT %IX3.4 : BOOL;
	ILAS_SWIO 			AT %IX3.5 : BOOL;
	ILAS_Redy	 		AT %IX3.6 : BOOL;
	ILAS_Res	 			AT %IX3.7 : BOOL;

	ILasDataBit0 			AT %IX4.0 : BOOL;
	ILasDataBit1 	 		AT %IX4.1 : BOOL;
	ILasDataBit2 		 	AT %IX4.2 : BOOL;
	ILasDataBit3 		 	AT %IX4.3 : BOOL;
	ILasDataBit4 	 		AT %IX4.4 : BOOL;
	ILasDataBit5 	 		AT %IX4.5 : BOOL;
	ILasResI1	 		 	AT %IX4.6 : BOOL;
	ILasResI2 			 	AT %IX4.7 : BOOL;

	(*Eing�nge f�r die Panel Tasten*)

	IAPosKS1Input  		AT%IW20:INT;	 	(*Speicher 1 F�llstand analoger Eingang*)
	IARES1				AT%IW22:INT;
	IASSIDgInput			 AT %ID44:UDINT;	(* Drehgeber *)


	QHAmpelGn		 	AT %QX0.0 : BOOL; (* Ventil Pneumatik  *)
	QHAmpelRt	  		AT %QX0.1 : BOOL; (* Ausgang 2 *)
	QHAmpelGb 			AT %QX0.2 : BOOL; (* Ausgang 3 *)
	QRES1				AT %QX0.3 : BOOL; (* Ausgang 4 *)
	QHTasteEin			AT %QX0.4 : BOOL; (* Ausgang 5 *)
	QHTasteAus			AT %QX0.5 : BOOL; (* Ausgang 6 *)
	QHTasteQuitt			AT %QX0.6 : BOOL; (* Ausgang 7 *)
	QRES2				AT %QX0.7 : BOOL; (* Ausgang 8 *)

	QLasMark				AT %QX1.0 : BOOL; (* Ausgang 9 *)
	QLasMarkstop		AT %QX1.1 : BOOL; (* Ausgang 10 *)
	QLasProg1			AT %QX1.2 : BOOL; (* Ausgang 11 *)
	QLasProg2			AT %QX1.3 : BOOL; (* Ausgang 12 *)
	QLasRes2			AT %QX1.4 : BOOL; (* Ausgang 13 *)
	QLasRes3			AT %QX1.5 : BOOL; (* Ausgang 14 *)
	QFrgNaechst			AT %QX1.6 : BOOL; (* Ausgang 15 *)
	QAntriebeEin		     	AT %QX1.7 : BOOL; (* Ausgang 16 *)

	QMotVor	 			AT %QX2.0 : BOOL; (* Ausgang 9 *)
	QMotRueck			AT %QX2.1 : BOOL; (* Ausgang 10 *)
	QSaugAnford			AT %QX2.2 : BOOL; (* Ausgang 11 *)
	QVIndex				AT %QX2.3 : BOOL; (* Ausgang 12 *)
	QVUeberlast			AT %QX2.4 : BOOL; (* Ausgang 13 *)
	QRES5				AT %QX2.5 : BOOL; (* Ausgang 14 *)
	QRES6				AT %QX2.6 : BOOL; (* Ausgang 15 *)
	QRES7			     	AT %QX2.7 : BOOL; (* Ausgang 16 *)

	QASollwMot			AT%QW4:WORD; (*Ausgangswort 1*)
	QARes				 	AT%QW6:WORD; (*Ausgangswort 2*)

(* Anfang der Variablen f�r Kopmunikation SPS <> Visu *)
	TP_LaserAktiv	:		BOOL;
	TP_LaserHand:			BOOL;
	TP_RefSetzen:			BOOL;
	TP_KammeraAktiv:		BOOL;
	TP_MVor:				BOOL;
	TP_MVorS:				BOOL;
	TP_Mrueck:				BOOL;
	TP_MrueckS:				BOOL;
	TP_Hand:				BOOL;
	TP_Auto:					BOOL;
	TP_ZNullen:				BOOL;   (*not included yet*)
	TPTypIndex:				WORD; (*not included yet*)
	TPTypSpeichern:			BOOL;   (*not included yet*)
	TPKettenTyp: 			ARRAY[0..3] OF WORD;  (*not included yet*)

	S_StUeberlast:			BOOL;
	S_StLaser:				BOOL;
	S_StKammera:			BOOL;
	S_StKupplung	:			BOOL;
	S_StSpeicherSchutz:		BOOL;
	S_StLaserSchutz:			BOOL;
	S_StSpeicher:				BOOL;
	S_StSammelstoerung:	BOOL;
	S_StDruck:				BOOL;
	S_StNotAus:				BOOL;
	S_StRef:					BOOL;

	S_StSchutzTuer:  BOOL;
	S_StSchutzHaube : BOOL;
         S_StAbsaugFilter : BOOL;
         S_StAbsaug100p : BOOL;


	S_MSpeicherVoll:			BOOL;
	S_MSpeicherLeer:		BOOL;
	S_MWarteSpeicher:		BOOL;
	S_MHand:					BOOL;
	S_FKamera:				BOOL;
	S_FLaser:					BOOL;
	S_MAutoStart:				BOOL;
	S_MAutoStop:				BOOL;
	SI_Gliederzahl:			INT;
	SI_ProgNr:				INT;
	SI_IO:						INT;
	SI_NIO:					INT;
	SI_FPosLaser:			INT;
	SI_FPosKamera:			INT;
	SKettenTyp:ARRAY[0..3] OF WORD;  (*not included yet*)
(* ENDE*)

	Skal_IC_SSI_DG_Input: 	DINT;
	Skal_SSI_DG_4:			DINT;
	ZeigerReg:				INT;
	ZeigerKette: 				INT;
	ImpulsPos: 				BOOL;
	ImpulsNeg: 				BOOL;
	Sammelstoerung: BOOL;

	V_Erster_Zyklus: BOOL;
	REF_IO: BOOL;
	AktTypIndexAlt: WORD;
	AktTypindex:WORD;
	PosErreicht: BOOL;


END_VAR

VAR_GLOBAL RETAIN

	(* KettenTyp[0] = Gliederzahl,  Kettentyp[1] Farbe1 0=grau 1=gelb 2=rot 3=blau, Kettentyp[2]=position der ersten Farblasche (Nr.d. Au�enlasche*)
	(*Kettentyp[3] Farbe2  Kettentyp[4] Position der zweiten Farblasche *)
	(*Kettentyp[6] Farbe3  Kettentyp[6] Position der dritten Farblasche *)
	(*Kettentyp[7] Farbe4  Kettentyp[8] Position der vierten Farblasche *)
	(*Kettentyp[9] Farbe5  Kettentyp[10] Position der f�nften Farblasche *)




	(*Hinterlegte Kettentypen 64 Kettentypen 0-63  , 0=>Gliederzahl, 1-3=>Positionen der ersten bis dritten Au�enlasche zum Lasern*)
	(*KettenTyp[x,2]=0 Bedeutet keine zweite Laserung an einer Kette*)
	(*KettenTyp[x,3]=0 Bedeutet keine dritte Laserung an einer Kette*)
	(*KettenTyp[x,1]=0 Nullter Kettentyp keine Laserung*)
	(*KettenTyp[x,0]=0 Ung�ltiger Eintrag *)

	(*Beispiel f�r eine Kette: 124 Glieder mit einer Laserung an der ersten Au�enlasche gespeichert als Typ 5*)
	(*KettenTyp[5,0]=124   Kettentyp[5,1]=1 Kettentyp[5,2]=0  Kettentyp[5,3]=0*)

	KettenTyp							AT%QW100:ARRAY [0..63,0..3] OF WORD;
	RegMarkierung					AT%QB500:ARRAY[1..500] OF BOOL;


(*   Fehlerz�hler f�r die erste Seite. Fehler k�nnen ohne Password zur�ckgesetzt werden*)

	SI_FKamera				AT%QW70:INT;
	SI_FLaser 				AT%QW72:INT;
(*	ZeigerGlied				AT%QW304:INT;				(* Zeiger f�r die Glieder in der Anlage zeigt auf das Glied unter der Trennstelle *)
	ZeigerAchtelGlied			AT%QW306:INT;
*)
END_VAR                                                                                               '              , X t �}           Variable_Configuration 4e�F	4e�F                        VAR_CONFIG
END_VAR
                                                                                               '              , n � ��           Variablen_Konfiguration 4e�F	4e�F     ����              VAR_CONFIG
END_VAR
                                                                                                    |0|0         ~      �   ���  �3 ���   � ���                  DEFAULT             System         |0|0   HH':'mm':'ss   dd'-'MM'-'yyyy'                           DriveControl 4e�F	4e�F                      M  TYPE DriveControl :
STRUCT
	ManOn: BOOL := FALSE; (* Visu -> SPS: Antrieb ein (nur bei FU-Antrieben) *)
	ManOff: BOOL := FALSE; (* Visu -> SPS: Antrieb aus (nur bei FU-Antrieben) *)
	ManFwd: BOOL := FALSE; (* Visu -> SPS: Antrieb im Handbetrieb langsam vorw�rts *)
	ManBwd: BOOL := FALSE; (* Visu -> SPS: Antrieb im Handbetrieb langsam r�ckw�rts *)
	TeilungVor: BOOL := FALSE; (* Visu -> SPS: Kette um eine Teilung vor (nur bei Servo-Antrieben) *)
	TeilungZur: BOOL := FALSE; (* Visu -> SPS: Kette um eine Teilung zur�ck (nur bei Servo-Antrieben) *)
	EnManCtrl: BOOL := FALSE; (* SPS -> Visu: Freigabe manuelle Steuerung *)
	ActOn: BOOL := FALSE; (* SPS -> Visu: Antrieb eingeschaltet *)
	ActOff: BOOL := FALSE; (* SPS -> Visu: Antrieb ausgeschaltet *)
	Error: BOOL := FALSE; (* SPS -> Visu: St�rung Antrieb *)
END_STRUCT
END_TYPE
                  is->PSAn        	   KettenTyp 4e�F	4e�F      E;* su>         �   TYPE KettenTyp :
STRUCT
	PF: ARRAY [0..19] OF UDINT := 0,410,819,1229,1638,2048,2458,2867,3277,3686,4049,4506,4915,5328,5734,6144,6554,6963,7373,7782;

END_STRUCT
END_TYPE                , , : ��        
   KS_Control 4e�F	4e�F                      �   TYPE KS_Control :
STRUCT
	EnInput: BOOL := FALSE; (* Freigabe Bef�llen *)
	EnOutput: BOOL := FALSE; (* Freigabe Entleeren *)
	ActState: INT := 0; (* aktueller zustand f�r Visu *)
END_STRUCT
END_TYPE                ,     #           KS_Control_1 4e�F	4e�F                      �   TYPE KS_Control_1 :
STRUCT
	EnInput: BOOL := FALSE; (* Freigabe Bef�llen *)
	EnOutput: BOOL := FALSE; (* Freigabe Entleeren *)
	ActState: INT := 0; (* aktueller zustand f�r Visu *)
END_STRUCT
END_TYPE                ,   9+           MotorControl 4e�F	4e�F       �t@t@        �  TYPE MotorControl :
STRUCT
	ManOn: BOOL := FALSE; (* Visu -> SPS: Antrieb im Handbetrieb ein *)
	ManOff: BOOL := FALSE; (* Visu -> SPS: Antrieb im Handbetrieb aus *)
	EnManCtrl: BOOL := FALSE; (* SPS -> Visu: Freigabe manuelle Steuerung *)
	ActOn: BOOL := FALSE; (* SPS -> Visu: Antrieb eingeschaltet *)
	ActOff: BOOL := FALSE; (* SPS -> Visu: Antrieb ausgeschaltet *)
	Error: BOOL := FALSE; (* SPS -> Visu: St�rung Antrieb *)
END_STRUCT
END_TYPE
                                     PneumControl 4e�F	4e�F                      �  TYPE PneumControl :
STRUCT
	SetOn: BOOL := FALSE; (* Visu -> SPS: Arbeitsstellung anfahren *)
	SetOff: BOOL := FALSE; (* Visu -> SPS: Grundstellung anfahren *)
	EnSet: BOOL := FALSE; (* SPS -> Visu: Freigabe manuell Steuerung *)
	ActOn: BOOL := FALSE; (* SPS -> Visu: Zylinder in Arbeitsstellung *)
	ActOff: BOOL := FALSE; (* SPS -> Visu: Zylinder in Grundstellung *)
	Error: BOOL := FALSE; (* SPS -> Visu: St�rung Zylinder oder Endschalter *)
END_STRUCT
END_TYPE
                     /         
   PosControl 4e�F	4e�F          �|          �  TYPE PosControl :
STRUCT
	PosSet: INT := 0; (* Positionssollwert [mm] *)
	ActPos: INT := 0; (* Positionsistwert [mm] *)
	PosLimitLo: INT := 0; (* unterer Grenzwert Sollposition [mm] *)
	PosLimitHi: INT := 0; (* oberer Grenzwert Sollposition [mm] *)
	StartPos: BOOL := FALSE; (* Visu -> SPS: Positionierung starten *)
	StoppPos: BOOL := FALSE; (* Visu -> SPS: Positionierung abbrechen *)
	ManPosUp: BOOL := FALSE; (* Visu -> SPS: Handbetrieb Positon erh�hen *)
	ManPosDn: BOOL := FALSE; (* Visu -> SPS: Handbetrieb Positon verringern *)
	EnPosSet: BOOL := FALSE; (* SPS -> Visu: Freigabe Sollwerteingabe *)
	EnManPos: BOOL := FALSE; (* SPS -> Visu: Freigabe manuelle Positionierung *)
	ActOn: BOOL := FALSE; (* SPS -> Visu: Antrieb eingeschaltet *)
	ActOff: BOOL := FALSE; (* SPS -> Visu: Antrieb ausgeschaltet *)
	Error: BOOL := FALSE; (* SPS -> Visu: St�rung Antrieb *)
END_STRUCT
END_TYPE
                                     StationControl 4e�F	4e�F                      O  TYPE StationControl :
STRUCT
	StepCounter: INT; (* SPS -> Visu: Schrittz�hler *)
	SingleStep: BOOL := FALSE; (* Visu -> SPS: Einzelschritt weiterschalten *)
	SingleCycle: BOOL := FALSE; (* Visu -> SPS: Einzelzyklus ausf�hren *)
	StartCycle: BOOL := FALSE; (* Zyklus im Auto-Betrieb starten *)
	ManInit: BOOL := FALSE; (* Visu -> SPS: Grundstellung anfahren *)
	AutoInit: BOOL := FALSE; (* Grundstellung im Auto-Betrieb anfahren *)
	SetFinished: BOOL := FALSE; (* Visu -> SPS: Fertigmeldung setzen *)
	WaitPos: BOOL := FALSE; (* Station in Warteposition f�r Stopp *)
	EnSemiAutoCtrl: BOOL := FALSE; (* SPS -> Visu: Steuerung Halbautomatikbetrieb freigeben; Freigabe f�r SingleStep, SingleCycle, InitPos und SetFinished *)
	InitPos: BOOL := FALSE; (* Station in Grundstellung *)
	Finished: BOOL := FALSE; (* Station fertig *)
	ErrorInitPos: BOOL := FALSE; (* St�rung Grundstellung nicht erreicht *)
	ErrorCycleTime: BOOL := FALSE; (* St�rung Zeit�berschreitung Zyklus *)
	ActState: INT := 0; (* SPS -> Visu: Zustand der Station: 0 = St�rung, 1 = bereit, 2 = aktiv *)
END_STRUCT
END_TYPE
                 , � � ��           AsmSollW 4e�F	4e�F                      �   FUNCTION_BLOCK AsmSollW
VAR

END_VAR

VAR_INPUT
	Auto: BOOL;
	Stufe: INT;
	Hand: BOOL;
END_VAR
VAR_OUTPUT
	Sollw: INT;
END_VARi   
IF  Auto = TRUE THEN
	Sollw:=Stufe * 5000;
END_IF

IF	Hand=TRUE  THEN
	Sollw:=12000;
END_IF


               	   , , : OH           Betriebsarten 4e�F	4e�F      �h  NG        S   FUNCTION_BLOCK Betriebsarten
VAR_INPUT
END_VAR
VAR_OUTPUT
END_VAR
VAR
END_VAR      TP_Hand�TP_AutoAND S_MHandS_MAutoStopS_MAutoStart     TP_Auto�TP_HandAIHWT_EINAND S_MAutoStartS_MHandS_MAutoStop     TP_Auto�TP_HandAIHWT_AUSAND S_MAutoStopS_MHandS_MAutoStartd                  1   ,     �           Indexsteuernung 4e�F	4e�F      	 pP8H9        �   FUNCTION_BLOCK Indexsteuernung
VAR_INPUT
END_VAR
VAR_OUTPUT
END_VAR
VAR
	SR1: RS;
	PF_1: R_TRIG;
	PF2: R_TRIG;
	PF_3: R_TRIG;
END_VAR      SR1S_MHandPF_1AISchutzhaubeR_TRIG      	ILAS_RedyATP_LaserHandANDBS_MAutoStartEPF2APosErreichtR_TRIG      ANDORBS_MHandTP_LaserHand�ISchutzhaubeANDBS_MAutoStartEPF_3A	ILAS_RedyR_TRIG      ANDORRS        QVIndexd                     , n � ��           INIT 4e�F	4e�F                         PROGRAM INIT

VAR

END_VAR  

(* Der Kettentyp wird von Laserrechner ausgew�hlt *)
AktTypIndex.0:=ILasDataBit0;
AktTypIndex.1:=ILasDataBit1;
AktTypIndex.2:=ILasDataBit2;
AktTypIndex.3:=ILasDataBit3;
AktTypIndex.4:=ILasDataBit4;
AktTypIndex.5:=ILasDataBit5;


(* Wenn Kettentyp gewechselt wurde mu� erneut referenziert werden *)
IF AktTypIndex <> AktTypIndexAlt THEN
	REF_IO:=FALSE;
END_IF
AktTypIndexAlt:=AktTypIndex;


(* Wenn die Maschine eingeschaltet wird ist eine Ref Fahrt durchzuf�hren *)
IF V_Erster_Zyklus=FALSE THEN
	REF_IO:=FALSE;
END_IF
V_Erster_Zyklus:=TRUE;



(* Trennstelle der Kette auf Indexposition fahren und Referenzieren *)
IF REF_IO= FALSE AND TP_RefSetzen= TRUE THEN
	ZeigerKette:=KettenTyp[AktTypIndex,0];
	REF_IO:=TRUE;
END_IF
TP_Refsetzen:=FALSE;


               
   , X t {�           Kettenspeicher 4e�F	4e�F                      �   FUNCTION_BLOCK Kettenspeicher
VAR_INPUT
END_VAR
VAR_OUTPUT
	KSenableInput: BOOL;
	KSenableOutput: BOOL;
END_VAR
VAR
END_VAR      IAPosKS1InputA28000LT  KSenableInput     IAPosKS1InputA2000GT  KSenableOutputd                  5   , n � ��           Kettentypen 4e�F	4e�F      9   &         Q   FUNCTION_BLOCK Kettentypen
VAR_INPUT
END_VAR
VAR_OUTPUT
END_VAR
VAR
END_VAR�  (*  Angew�hlten Kettentyp f�r Visu bereitstellen *)

SKettenTyp[0]:=KettenTyp[TPTypIndex,0];
SKettenTyp[1]:=KettenTyp[TPTypIndex,1];
SKettenTyp[2]:=KettenTyp[TPTypIndex,2];
SKettenTyp[3]:=KettenTyp[TPTypIndex,3];


(* Editierte Kettentypen remanent speichern *)
IF TPTypSpeichern = TRUE THEN
	KettenTyp[TPTypIndex,0]:=TPKettenTyp[0];
	KettenTyp[TPTypIndex,0]:=TPKettenTyp[0];
	KettenTyp[TPTypIndex,0]:=TPKettenTyp[0];
	KettenTyp[TPTypIndex,0]:=TPKettenTyp[0];
END_IF

	TPTypSpeichern:= FALSE;
                  , ��m n�           MAIN_1 4e�F	4e�F      �               5  PROGRAM MAIN_1
VAR
	SollPos1: SollPos;
	Stufe1: INT;
	ASMSollW1: AsmSollW;
	Poserreicht: BOOL;
	Motorsteuerung1: Motorsteuerun;
	Betriebsarten1: Betriebsarten;
	Kettenspeicher1: Kettenspeicher;
	KSEnIn: BOOL;
	KSEnOut: BOOL;
	Saugersteuerung1: Saugersteuerung;
	Kettentypen1: Kettentypen;
END_VAR	      ???�INIT           Kettentypen1�Kettentypen           ???�Nockenschaltwerk           Betriebsarten1�Betriebsarten           SollPos1�SollPos        Stufe1     	ASMSollW1TP_AutoStufe1ATP_HandAsmSollW        
QASollwMot     Kettenspeicher1�Kettenspeicher  KSEnOut      KSEnIn     Motorsteuerung1PoserreichtKSEnInAKSEnOutMotorsteuerun           Saugersteuerung1�Saugersteuerung      d                     , n � �           MAIN_2 4e�F	4e�F          	 `            PROGRAM MAIN_2
VAR
END_VAR   ;                  ,   9+           Motorsteuerun 4e�F	4e�F      �  p� I        �   FUNCTION_BLOCK Motorsteuerun
VAR_INPUT
	Poserreicht: BOOL;
	KSenableInput: BOOL;
	KSEnableOutput: BOOL;
END_VAR
VAR_OUTPUT
END_VAR
VAR
	PF_AutoStart: R_TRIG;
	PF_AutoStop: R_TRIG;
	StopGoMot: RS;
END_VAR .   Ansteuerung des Motors M1 in Positive richtung S_MHandTP_MVorAIHWT_EINANDE	StopGoMotS_MAutoStartIHWT_EINA	ILAS_RedyANDBS_MAutoStartEPF_AutoStartA	ILAS_RedyR_TRIG      ANDORBPF_AutoStopAPoserreichtR_TRIG      S_MHandIHWT_AUSAS_MAutoStopORRS      OR	ILAS_RedyKSenableInput�FALSEATRUEAND  QMotVor)   Ansteuerung Motor M1 in negative Richtung S_MHand	TP_MrueckAIHWT_EINANDKSEnableOutputTRUE�FALSEAND  	QMotRueckd                     ,  � �E           Nockenschaltwerk 4e�F	4e�F       � PX8�        �   PROGRAM Nockenschaltwerk
VAR
	Zeiger :INT:=0;
	Nocke:BOOL:=FALSE;
	Zaeler:WORD;
	(*Skal_IC_SSI_DG_Input: DINT;*)
	Skal_IC_SSI_DG_Input_Alt:DINT;
	Skal_IC_SSI_DG_Input_Delta:DINT;
	Skal_SSI_DG_4_Alt: DINT;
	ImpulsPos4: BOOL;
END_VAR
s  (*  Miroslav Knezevic TCM 19.03.07  *)
(* Baustein bildet Zeiger f�r Speicher (Speichertiefe 500 Glieder) und Zeiger f�r Kette ( Speichertiefe variabel*)
(* Baustein liefert Impulse bei drehen in positiver Richtung und impulse bei Drehen in negativer Richtung*)
(*  Das Nockenschaltwerk liefert 32 Impulse (32 Glieder(Z�hne)  bei einer Umdrehung des SSI Drehgebers *)
(* Voller Kreis = 16777216 Inkremente,  1 Impuls= 524288 Inkremente *)



Skal_IC_SSI_DG_Input:=IASSIDgInput/524288;
Skal_IC_SSI_DG_Input_Delta:=Skal_IC_SSI_DG_Input - Skal_IC_SSI_DG_Input_Alt;


(* Bildung der Virtelgliedimpulse *)
Skal_SSI_DG_4:=IASSIDgInput/131072;
IF Skal_SSI_DG_4 <> Skal_SSI_DG_4_Alt THEN
	ImpulsPos4:=TRUE;
ELSE
	ImpulsPos4:=FALSE;
END_IF
Skal_SSI_DG_4_Alt:=Skal_SSI_DG_4;


IF Skal_IC_SSI_DG_Input_Delta<-10 THEN
	Skal_IC_SSI_DG_Input_Delta:=1;
END_IF

IF Skal_IC_SSI_DG_Input_Delta>10 THEN
	Skal_IC_SSI_DG_Input_Delta:=-1;
END_IF


ZeigerReg:=DINT_TO_INT(ZeigerReg+Skal_IC_SSI_DG_Input_Delta);
IF ZeigerReg>500 THEN
	ZeigerReg:=ZeigerReg-500;
END_IF
IF ZeigerReg<1 THEN
	ZeigerReg:=ZeigerReg+500;
END_IF


ZeigerKette:=DINT_TO_INT(ZeigerKette+Skal_IC_SSI_DG_Input_Delta);
IF ZeigerKette>KettenTyp[AktTypindex,0] THEN
	ZeigerKette:=ZeigerKette-KettenTyp[AktTypindex,0];
END_IF

IF ZeigerKette<1 THEN
	ZeigerKette:=ZeigerKette-KettenTyp[AktTypindex,0];
END_IF


IF Skal_IC_SSI_DG_Input_Delta>0 THEN
	ImpulsPos:=TRUE;
ELSE
	ImpulsPos:=FALSE;
END_IF;

IF Skal_IC_SSI_DG_Input_Delta<0 THEN
	ImpulsNeg:=TRUE;
ELSE
	ImpulsNeg:=FALSE;
END_IF;



Skal_IC_SSI_DG_Input_Alt:=Skal_IC_SSI_DG_Input;



                  , n � ��           Saugersteuerung 4e�F	4e�F                      U   FUNCTION_BLOCK Saugersteuerung
VAR_INPUT
END_VAR
VAR_OUTPUT
END_VAR
VAR
END_VAR      �INot_Aus�SammelstoerungAND  QSaugAnford QAntriebeEind                     , � � V�           SollPos 4e�F	4e�F                      �   FUNCTION_BLOCK SollPos
VAR_INPUT
END_VAR
VAR_OUTPUT
	Stufe: INT;

END_VAR
VAR
	ZeigerStufe1: INT;
	ZeigerStufe2: INT;
	ZeigerStufe3: INT;
	ZeigerStufe4: INT;
	ZeigerStufe5: INT;
END_VAR�	  (*
(* Kettenanfang im Handbetrieb setzen *)
IF H_Handbetrieb= TRUE AND TasteKettenanfang=TRUE  THEN
	Zeiger_Kette_Trennstelle:=KettenTyp[0];
	Sperre_2Pruef :=TRUE;
END_IF


(* Auftragswechsel *)

IF	KettenTyp[0] <> Gliederzahl_Alt THEN
	Zeiger_Kette_Trennstelle:= KettenTyp[0];
	Sperre_2Pruef :=TRUE;
END_IF
Gliederzahl_Alt:=KettenTyp[0];
*)


IF	ImpulsPos =TRUE THEN


	(*Alten Eintrag im Register L�schen*)
	(*Laser wird dann die Markierung eintragen*)
	RegMarkierung[ZeigerKette]:=FALSE;

	(* Geschwindigkeitsstufen f�r die Positionierung ermitteln *)
	(* Zeiger f�r die Stufen berechnen *)
	(* Bearbeitung nur wenn Aussenlasche*)
	IF ZeigerKette.0=FALSE THEN
		ZeigerStufe1:=ZeigerKette+2;
		IF ZeigerStufe1>KettenTyp[AktTypindex,0] THEN
			ZeigerStufe1:=ZeigerStufe1-KettenTyp[AktTypindex,0];
		END_IF
		ZeigerStufe2:=ZeigerStufe1+2;
		IF ZeigerStufe2>KettenTyp[AktTypindex,0] THEN
			ZeigerStufe2:=ZeigerStufe2-KettenTyp[AktTypindex,0];
		END_IF
		ZeigerStufe3:=ZeigerStufe2+2;
		IF ZeigerStufe3>KettenTyp[AktTypindex,0] THEN
			ZeigerStufe3:=ZeigerStufe3-KettenTyp[AktTypindex,0];
		END_IF
		ZeigerStufe4:=ZeigerStufe3+2;
		IF ZeigerStufe4>KettenTyp[AktTypindex,0] THEN
			ZeigerStufe4:=ZeigerStufe4-KettenTyp[AktTypindex,0];
		END_IF
		ZeigerStufe5:=ZeigerStufe4+2;
		IF ZeigerStufe5>KettenTyp[AktTypindex,0] THEN
			ZeigerStufe5:=ZeigerStufe5-KettenTyp[AktTypindex,0];
		END_IF

		IF ZeigerStufe5 = KettenTyp[AktTypindex,1]*2 OR ZeigerKette = KettenTyp[AktTypindex,2]*2 OR ZeigerKette = KettenTyp[AktTypindex,3]*2THEN
			Stufe:=5;
		ELSE
			Stufe:=6;
		END_IF

		IF ZeigerStufe4 = KettenTyp[AktTypindex,1]*2 OR ZeigerKette = KettenTyp[AktTypindex,2]*2 OR ZeigerKette = KettenTyp[AktTypindex,3]*2THEN
			Stufe:=4;
		END_IF

		IF ZeigerStufe3 = KettenTyp[AktTypindex,1]*2 OR ZeigerKette = KettenTyp[AktTypindex,2]*2 OR ZeigerKette = KettenTyp[AktTypindex,3]*2THEN
			Stufe:=3;
		END_IF

		IF ZeigerStufe2 = KettenTyp[AktTypindex,1]*2 OR ZeigerKette = KettenTyp[AktTypindex,2]*2 OR ZeigerKette = KettenTyp[AktTypindex,3]*2THEN
			Stufe:=2;
		END_IF

		IF ZeigerStufe1 = KettenTyp[AktTypindex,1]*2 OR ZeigerKette = KettenTyp[AktTypindex,2]*2 OR ZeigerKette = KettenTyp[AktTypindex,3]*2THEN
			Stufe:=1;
		END_IF

		IF ZeigerKette = KettenTyp[AktTypindex,1]*2 OR ZeigerKette = KettenTyp[AktTypindex,2]*2 OR ZeigerKette = KettenTyp[AktTypindex,3]*2THEN
		PosErreicht:=TRUE;
		END_IF

	END_IF
END_IF

                                        visu 4e�F       d                                                                                                              � Z -� �   ���     ���                                                                      ���                                                                                                                                            �2 1� �n   ���     ���                                                                     ���                                                                                                                                            � ��M@  ���     ���                                                                     ���                                                                                                                                            rhO���  ���     ���                                                                     ���                                          �   ��   �   ��   � � � ���     �   ��   �   ��   � � � ���                  ����                   "   STANDARD.LIB 5.6.98 12:03:02 @V�w5      CONCAT @                	   CTD @        	   CTU @        
   CTUD @           DELETE @           F_TRIG @        
   FIND @           INSERT @        
   LEFT @        	   LEN @        	   MID @           R_TRIG @           REPLACE @           RIGHT @           RS @        
   SEMA @           SR @        	   TOF @        	   TON @           TP @              Global Variables 0 @                        , B W ��           2                ����������������  
             ����  X���            ����  r_eierre                   	   Bausteine            
   Funktionen  ����              Funktionsbausteine                 AsmSollW                     Betriebsarten  	                   Indexsteuernung  1                   Kettenspeicher  
                   Kettentypen  5                   Motorsteuerun                     Saugersteuerung                     SollPos     ����                INIT                     MAIN_1                     MAIN_2                    Nockenschaltwerk     ����           
   Datentypen                 DriveControl                  	   KettenTyp                  
   KS_Control                    KS_Control_1                     MotorControl                     PneumControl                  
   PosControl                     StationControl     ����             Visualisierungen                 visu     ����              Globale Variablen                Globale_Variablen                     Variable_Configuration                     Variablen_Konfiguration     ����                                                              �f/F                         	   localhost            P      	   localhost            P      	   localhost            P             �`