CoDeSys+W   �         �         @        @   2.3.6.0    @    @             ՒF +    @      ��������             ��C        y>   @      C:\TWINCAT\PLC\LIB\STANDARD.LIB          CONCAT               STR1               ��              STR2               ��                 CONCAT                                         ��66  �   ����           CTD           M             ��           Variable for CD Edge Detection      CD            ��           Count Down on rising edge    LOAD            ��           Load Start Value    PV           ��           Start Value       Q            ��           Counter reached 0    CV           ��           Current Counter Value             ��66  �   ����           CTU           M             ��            Variable for CU Edge Detection       CU            ��       
    Count Up    RESET            ��           Reset Counter to 0    PV           ��           Counter Limit       Q            ��           Counter reached the Limit    CV           ��           Current Counter Value             ��66  �   ����           CTUD           MU             ��            Variable for CU Edge Detection    MD             ��            Variable for CD Edge Detection       CU            ��	       
    Count Up    CD            ��
           Count Down    RESET            ��           Reset Counter to Null    LOAD            ��           Load Start Value    PV           ��           Start Value / Counter Limit       QU            ��           Counter reached Limit    QD            ��           Counter reached Null    CV           ��           Current Counter Value             ��66  �   ����           DELETE               STR               ��              LEN           ��              POS           ��                 DELETE                                         ��66  �   ����           F_TRIG           M             ��
                 CLK            ��           Signal to detect       Q            ��           Edge detected             ��66  �   ����           FIND               STR1               ��              STR2               ��                 FIND                                     ��66  �   ����           INSERT               STR1               ��              STR2               ��              POS           ��                 INSERT                                         ��66  �   ����           LEFT               STR               ��              SIZE           ��                 LEFT                                         ��66  �   ����           LEN               STR               ��                 LEN                                     ��66  �   ����           MID               STR               ��              LEN           ��              POS           ��                 MID                                         ��66  �   ����           R_TRIG           M             ��
                 CLK            ��           Signal to detect       Q            ��           Edge detected             ��66  �   ����           REPLACE               STR1               ��              STR2               ��              L           ��              P           ��                 REPLACE                                         ��66  �   ����           RIGHT               STR               ��              SIZE           ��                 RIGHT                                         ��66  �   ����           RS               SET            ��              RESET1            ��                 Q1            ��
                       ��66  �   ����           SEMA           X             ��                 CLAIM            ��	              RELEASE            ��
                 BUSY            ��                       ��66  �   ����           SR               SET1            ��              RESET            ��                 Q1            ��	                       ��66  �   ����           TOF           M             ��           internal variable 	   StartTime            ��           internal variable       IN            ��       ?    starts timer with falling edge, resets timer with rising edge    PT           ��           time to pass, before Q is set       Q            ��	       2    is FALSE, PT seconds after IN had a falling edge    ET           ��
           elapsed time             ��66  �   ����           TON           M             ��           internal variable 	   StartTime            ��           internal variable       IN            ��       ?    starts timer with rising edge, resets timer with falling edge    PT           ��           time to pass, before Q is set       Q            ��	       0    is TRUE, PT seconds after IN had a rising edge    ET           ��
           elapsed time             ��66  �   ����           TP        	   StartTime            ��           internal variable       IN            ��       !    Trigger for Start of the Signal    PT           ��       '    The length of the High-Signal in 10ms       Q            ��	           The pulse    ET           ��
       &    The current phase of the High-Signal             ��66  �   ����                  _ASM_FU_SOLLW               SollW           ,               IstW           ,               P           ,               Pos_Fenster           ,                  SollwReg           , 	           	   Vor_Rueck            , 
              Pos_Erreicht            ,                        M+F  @    ����           CLEARTESTARRAYS        
   ClearArray   	                     8(0)             >                  enable            >        
    Freigabe           Gelenk_I    	                        > 	              Gelenk_A    	                        > 
              Vollstaendigkeit    	                        >               Nietung    	                        >               ZZP    	                        >               Huelse    	                        >                    M+F  @    ����           CLOCKDIVIDE        	   clock_old             @               counter            @                  clock_in            @            clock input    n           @        	    divider    	   clock_out            @                        M+F  @    ����           ERRMOVE           i            *               n            *                  ErrArray   	  �                       *                  ErrWordArray   	                         * 
                       M+F  @    ����           INTSCALE               Int_In           2            Eingangsvariable 
   Real_Scale            2            Skalierfaktor    Int_Zero           2            Nullpunkt       IntScale                                     M+F  @    ����           KETTENREGISTER           AKT_KettenTyp_Alt            . 	                               M+F  @    ����           KS           KS_ready             #            Kettenspeicher bereit    ActKapazitaet            #        /    aktuelle Kettenspeicher-Kapazit�t in Gliedern       URL_Geschlossen            #            Umlenkrolle geschlossen    SpannzylinderGespannt            #        '    Spannzylinder Kettenspeicher gespannt    ActPress           #            Druck-Istwert Spannzylinder 
   ActPos_ULR           #            Positions-Istwert Umlenkrolle    MinPress           #            minimaler Druck Spannzylinder    MaxPress           #            maximaler Druck Spannzylinder 
   MinPos_ULR           # 	           minimale Position Umlenkrolle 
   MaxPos_ULR           # 
           maximale Position Umlenkrolle    MaxKapazitaet           #        /    maximale Kettenspeicher-Kapazit�t in Gliedern    Gliederzahl_InTakt           #        E    Gliederzahl f�r getaktetes Bef�llen (0 = konstante Geschwindigkeit)    Gliederzahl_OutTakt           #        D    Gliederzahl f�r getaktete Entnahme (0 = konstante Geschwindigkeit)       En_Input            #            Freigabe Bef�llen 	   En_Output            #            Freigabe Entnahme    ActState           #            aktueller Zustand f�r Visu             M+F  @    ����           NOCKENSCHALTWERK           Zeiger            V               Nocke             V               Zaeler            V               Skal_IC_SSI_DG_Input            V               Skal_IC_SSI_DG_Input_Alt            V               Skal_IC_SSI_DG_Input_Delta            V               CTU2            V 	                               M+F  @    ����           OUTCTRLB           TO_Zyl                    TON    +                  AutoSet            +        )    Ausgang im Automatikbetrieb einschalten 	   AutoReset            +        )    Ausgang im Automatikbetrieb ausschalten 
   AutoEnable            +        "    Ausgangsfreigabe im Auto-Betrieb 	   ManEnable            + 	       !    Ausgangsfreigabe im Handbetrieb    INI_Home            + 
           Initiator Grundstellung    INI_End            +            Initiator Arbeitsstellung    HoldHome            +        #    Ventil in Grundstellung bestromen    HoldEnd            +        %    Ventil in Arbeitsstellung bestromen 
   ResetError            +            St�rung r�cksetzen 
   ManualMode            +            Betriebsart Hand    Timeout           +            Zeit�berwachung    clock            +            Takt f�r St�rung       OutEnd            +        1    Ausgang Endstellung f�r bistabiles Magnetventil    OutHome            +        1    Ausgang Endstellung f�r bistabiles Magnetventil    EnManControl            +        %    Freigabe Visu-Steuerung Handbetrieb    ActEnd            +        !    aktueller Zustand eingeschaltet    ActHome            +        !    aktueller Zustand ausgeschaltet    VisuErrorState            +            St�rmeldung f�r Visu    Error            +        ,    St�rung Pneumatikzylinder oder Endschalter       ManSet            +        '    Ausgang im Manuellbetrieb einschalten    ManReset            +        '    Ausgang im Manuellbetrieb ausschalten         M+F  @    ����        	   OUTCTRLKS           AutoOn             )        %    Ausgang im Auto-Betrieb einschalten    ManOn             )        (    Ausgang im Manuell-Betrieb einschalten    TO_Zyl                    TON    )                  AutoSet            )        )    Ausgang im Automatikbetrieb einschalten 	   AutoReset            ) 	       )    Ausgang im Automatikbetrieb ausschalten 
   AutoEnable            ) 
       #    Ausgangsfreigabe f�r Auto-Betrieb 	   ManEnable            )        "    Ausgangsfreigabe f�r Handbetrieb 	   ErrEnable            )            Freigabe Fehlerauswertung    INI_Home            )            Initiator Grundstellung    INI_End            )            Initiator Arbeitsstellung 
   ManualMode            )            Betriebsart Hand    Timeout           )            Zeit�berwachung 
   ResetError            )            St�rung r�cksetzen    clock            )            Takt f�r St�rung       Output            )        '    Ausgang f�r monostabiles Magnetventil    EnManControl            )        !    Freigabe Handsteuerung f�r Visu    ActEnd            )        !    aktueller Zustand eingeschaltet    ActHome            )        !    aktueller Zustand ausgeschaltet    VisuErrorState            )            Fehlermeldung aktivieren    Error            )        ,    St�rung Pneumatikzylinder oder Endschalter       ManSet            )        '    Ausgang im Manuellbetrieb einschalten    ManReset            )        '    Ausgang im Manuellbetrieb ausschalten         M+F  @    ����           OUTCTRLM           AutoOn             1        %    Ausgang im Auto-Betrieb einschalten    ManOn             1        (    Ausgang im Manuell-Betrieb einschalten    TO_Zyl                    TON    1                  AutoSet            1        )    Ausgang im Automatikbetrieb einschalten 	   AutoReset            1 	       )    Ausgang im Automatikbetrieb ausschalten 
   AutoEnable            1 
       #    Ausgangsfreigabe f�r Auto-Betrieb 	   ManEnable            1        "    Ausgangsfreigabe f�r Handbetrieb 	   ErrEnable            1            Freigabe Fehlerauswertung    INI_Home            1            Initiator Grundstellung    INI_End            1            Initiator Arbeitsstellung 
   ManualMode            1            Betriebsart Hand    Timeout           1            Zeit�berwachung 
   ResetError            1            St�rung r�cksetzen    clock            1            Takt f�r St�rung       Output            1        '    Ausgang f�r monostabiles Magnetventil    EnManControl            1        !    Freigabe Handsteuerung f�r Visu    ActEnd            1        !    aktueller Zustand eingeschaltet    ActHome            1        !    aktueller Zustand ausgeschaltet    VisuErrorState            1            Fehlermeldung aktivieren    Error            1        ,    St�rung Pneumatikzylinder oder Endschalter       ManSet            1        '    Ausgang im Manuellbetrieb einschalten    ManReset            1        '    Ausgang im Manuellbetrieb ausschalten         M+F  @    ����        
   SERVOKETTE           TOF_RFR                    TOF    0        %    Ausschaltverz�gerung Reglerfreigabe       AutoStartPos            0        )    Automatikbetrieb Positionierung starten    ManFwd            0            Handbetrieb vorw�rts    ManBwd            0 	           Handbetrieb r�ckw�rts 
   ManualMode            0 
           Betriebsart Manuell    NotAusOK            0            Not-Aus OK 
   DriveError            0            Antriebsst�rung    Servo_Ready            0            Antrieb bereit    RefError            0            St�rung Referenzierung    PosError            0            St�rung Positionierung 
   ResetError            0            St�rung r�cksetzen    Clock            0            Takt f�r Fehler    	   Servo_RFR            0            Servoumrichter Reglerfreigabe 
   Servo_CINH            0        *    Servoumrichter Reglersperre �ber CAN-Bus    ServoManFwd            0            Servoantrieb manuell vorw�rts    ServoManBwd            0             Servoantrieb manuell r�ckw�rts    ServoStartPos            0        %    Servoantrieb Positionierung starten    ServoTripReset            0        #    Servoumrichter St�rung r�cksetzen    ServoResetError            0        -    Servoumrichter St�rung Ref/Pos zur�cksetzen 	   EnManCtrl            0            Freigabe manuelle Steuerung    Visu_DriveOn            0            Visu: Antrieb eingeschaltet    Visu_DriveOff            0            Visu: Antrieb ausgeschaltet 
   Visu_Error            0            Visu: St�rung Antrieb    Error            0            Sammelst�rung Antrieb             M+F  @    ����           STATE               error            /        	    St�rung    busy            /            Station aktiv    finished            /            Station fertig       State                                     M+F  @    ����            
 1   2   0   #   +   )   1   ����,   ����   ����*   .      @   >   V   4   ( ?      K   �?     K   �?     K   �?     K   �?                 �?         +     ��localhost              �  0�]    �                   0� j� x�"x����(� >�#        �  0�]0�]  �   0�]��D\� ��        � @  ���D��D����D��D       ������h� ���w@��w����x�    �  0�]      �  0�]P� ��� P� 0� ��� (Q����<� �g�     ,   ,                                                        K         @   M+F�A  /*BECKCONFI3*/
        !�� @   @   �   �     3                  Standard            	�+F                        VAR_GLOBAL
END_VAR
                                                                                  "   , � � P=             Standard         Nockenschaltwerk();                   M+F                 $����,   �                                  Standard ��@	��@                                       	a+F                        VAR_CONFIG
END_VAR
                                                                                   '           4   , ��V u�           Globale_Variablen M+F	M+F4     ��������        Y  VAR_GLOBAL
	E1  AT %IX0.0 : BOOL; (* Eingang 1 *)
	E2  AT %IX0.1 : BOOL; (* Eingang 2 *)
	E3  AT %IX0.2 : BOOL; (* Eingang 3 *)
	E4  AT %IX0.3 : BOOL; (* Eingang 4 *)
	E5  AT %IX0.4 : BOOL; (* Eingang 5 *)
	E6  AT %IX0.5 : BOOL; (* Eingang 6 *)
	E7  AT %IX0.6 : BOOL; (* Eingang 7 *)
	E8  AT %IX0.7 : BOOL; (* Eingang 8 *)

       E9  AT %IX1.0 : BOOL; (* Eingang 9 *)
	E10  AT %IX1.1 : BOOL; (* Eingang 10 *)
	E11  AT %IX1.2 : BOOL; (* Eingang 11 *)
	E12  AT %IX1.3 : BOOL; (* Eingang 12 *)
	E13  AT %IX1.4 : BOOL; (* Eingang 13 *)
	E14  AT %IX1.5 : BOOL; (* Eingang 14 *)
	_KS1_UmlRolleGeschl  AT %IX1.6 : BOOL; (* Speicher 1 ist geschlo�en *)
	_KS2_UmlRolleGeschl  AT %IX1.7 : BOOL; (* Speicher 2 ist geschlo�en *)

	E17  AT %IX2.0 : BOOL; (* Eingang 17 *)
	E18  AT %IX2.1 : BOOL; (* Eingang 18 *)
	E19  AT %IX2.2 : BOOL; (* Eingang 19 *)
	E20  AT %IX2.3 : BOOL; (* Eingang 20 *)
	E21  AT %IX2.4 : BOOL; (* Eingang 21 *)
	E22  AT %IX2.5 : BOOL; (* Eingang 22 *)
	E23  AT %IX2.6 : BOOL; (* Eingang 23 *)
	E24  AT %IX2.7 : BOOL; (* Eingang 24 *)

	T_Quitt_NA  AT %IX3.0 : BOOL; (* Eingang 9 *)
	T_Qiutt_Stoerung  AT %IX3.1 : BOOL; (* Eingang 10 *)
	T_Hand  AT %IX3.2 : BOOL; (* Eingang 11 *)
	T_Auto  AT %IX3.3 : BOOL; (* Eingang 12 *)
	T_Visu  AT %IX3.4 : BOOL; (* Eingang 13 *)
	T_KammBild  AT %IX3.5 : BOOL; (* Eingang 14 *)
	T_Start  AT %IX3.6 : BOOL; (* Eingang 15 *)
	T_Stop  AT %IX3.7 : BOOL; (* Eingang 16 *)

	ET9   AT %IX4.0 : BOOL; (* Eingang 17 *)
	ET10  AT %IX4.1 : BOOL; (* Eingang 18 *)
	ET11  AT %IX4.2 : BOOL; (* Eingang 19 *)
	ET12  AT %IX4.3 : BOOL; (* Eingang 20 *)
	ET13  AT %IX4.4 : BOOL; (* Eingang 21 *)
	ET14  AT %IX4.5 : BOOL; (* Eingang 22 *)
	T_KettenAnfang  AT %IX4.6 : BOOL; (* Eingang 23 *)
	ET16  AT %IX4.7 : BOOL; (* Eingang 24 *)


	IA_Pos_KS1_Input  AT%IW8:INT;	 	(*Speicher 1 F�llstand analoger Eingang*)
	IA_Pos_KS2_Input	AT%IW12:INT;   	(*Speicher 2 F�llstand analoger Eingang*)
	VW_Act_Pos_KS1: INT;					(*Aktueller F�llstand Kettenspeicher 1 skaliert*)
	VW_Act_Pos_KS2:INT;					(*Aktueller F�llstand Kettenspeicher 2 skaliert*)
	IA_EW3	AT%IW12:INT; 				(*Analogeingang 3*)
	IA_EW4  	AT%IW16:INT; 				(*Analogeingang 4*)
	IC_SSI_DG_Input  AT %ID20:UDINT;	(* Drehgeber *)
	My_IC_SSI_DG_Input:UDINT;

	_PneumPressEin  AT %QX0.0 : BOOL; (* Ventil Pneumatik  *)
	A2  AT %QX0.1 : BOOL; (* Ausgang 2 *)
	A3  AT %QX0.2 : BOOL; (* Ausgang 3 *)
	A4  AT %QX0.3 : BOOL; (* Ausgang 4 *)
	A5  AT %QX0.4 : BOOL; (* Ausgang 5 *)
	A6  AT %QX0.5 : BOOL; (* Ausgang 6 *)
	A7  AT %QX0.6 : BOOL; (* Ausgang 7 *)
	A8  AT %QX0.7 : BOOL; (* Ausgang 8 *)

	Q_KS2_EnOutput  AT %QX1.0 : BOOL; (* Ausgang 9 *)
	A10  AT %QX1.1 : BOOL; (* Ausgang 10 *)
	A11  AT %QX1.2 : BOOL; (* Ausgang 11 *)
	A12  AT %QX1.3 : BOOL; (* Ausgang 12 *)
	A13  AT %QX1.4 : BOOL; (* Ausgang 13 *)
	A14  AT %QX1.5 : BOOL; (* Ausgang 14 *)
	A15  AT %QX1.6 : BOOL; (* Ausgang 15 *)
	A16  AT %QX1.7 : BOOL; (* Ausgang 16 *)

	H_Quitt_NA  AT %QX2.0 : BOOL; (* Ausgang 1 *)
	H_Quitt_Stoerung  AT %QX2.1 : BOOL; (* Ausgang 2 *)
	H_Hand  AT %QX2.2 : BOOL; (* Ausgang 3 *)
	H_Auto  AT %QX2.3 : BOOL; (* Ausgang 4 *)
	H_Visu  AT %QX2.4 : BOOL; (* Ausgang 5 *)
	H_KammBild  AT %QX2.5 : BOOL; (* Ausgang 6 *)
	H_Start  AT %QX2.6 : BOOL; (* Ausgang 7 *)
	H_Stop  AT %QX2.7 : BOOL; (* Ausgang 8 *)

	AT9  AT %QX3.0 : BOOL; (* Ausgang 9 *)
	AT10  AT %QX3.1 : BOOL; (* Ausgang 10 *)
	AT11  AT %QX3.2 : BOOL; (* Ausgang 11 *)
	AT12  AT %QX3.3 : BOOL; (* Ausgang 12 *)
	AT13  AT %QX3.4 : BOOL; (* Ausgang 13 *)
	AT14  AT %QX3.5 : BOOL; (* Ausgang 14 *)
	H_KettenAnfang  AT %QX3.6 : BOOL; (* Ausgang 15 *)
	AT16  AT %QX3.7 : BOOL; (* Ausgang 16 *)


	QA_Sollw_Mot1   AT%QW4:WORD; (*Ausgangswort 1*)
	QA_Sollw_Mot2   AT%QW8:WORD; (*Ausgangswort 2*)

	KettenTypen			AT%QW100:ARRAY [1..10,0..10] OF INT ;	(* Es k�nnen maximal 10 Kettentypen definiert und remanent gespeichert werden *)
	AKT_KettenTyp		AT%QW420:INT;								(* Nummer des g�ltigen Kettentyps ( 1-10)   *)
	Speicher_Reg: ARRAY[0..500] OF WORD;							(* Speicherregister f�r Glieder es werden maximal 500 Glieder beobachtet *)
	Ketten_Reg: ARRAY[0..220] OF WORD;								(* Kettenregister f�r dien Aktuellen Kettentyp *)
	Z_AKT_KettenTyp_Max:INT;											(* L�nge des Aktuellen Kettentyps *)
	Zeiger_Speicher_Trennstelle: INT;									(* Zeiger f�r die Glieder in der Anlage zeigt auf das Glied unter der Trennstelle *)
	Zeiger_Kette_Trennstelle:INT;										(* Zeiger f�r die Glieder der Kette zeigt auf das Glied unter der Trennstelle*)
	Zeiger_Loeschen: INT;												(* Zeiger zum L�schen der Register beim �berlauf *)
	M1:BOOL;

	CTU1: CTU;
END_VAR
                                                                                               '           	   , �� G�           Variable_Configuration M+F	M+F	                        VAR_CONFIG
END_VAR
                                                                                               '           '   , ��V ��           Variablen_Konfiguration M+F	M+F'     ��������           VAR_CONFIG
END_VAR
                                                                                                    |0|0         ~      �   ���  �3 ���   � ���                  DEFAULT             System         |0|0   hh':'mm':'ss   dd'-'MM'-'yyyy'   $   ,  $ ��           DriveControl M+F	M+F         ��        M  TYPE DriveControl :
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
             (   , t�O ��        	   KettenTyp M+F	M+F      ��������        �   TYPE KettenTyp :
STRUCT
	PF: ARRAY [0..19] OF UDINT := 0,410,819,1229,1638,2048,2458,2867,3277,3686,4049,4506,4915,5328,5734,6144,6554,6963,7373,7782;

END_STRUCT
END_TYPE             !   ,  > �        
   KS_Control M+F	M+F       I;  aue        �   TYPE KS_Control :
STRUCT
	EnInput: BOOL := FALSE; (* Freigabe Bef�llen *)
	EnOutput: BOOL := FALSE; (* Freigabe Entleeren *)
	ActState: INT := 0; (* aktueller zustand f�r Visu *)
END_STRUCT
END_TYPE             -   ,  < �           MotorControl M+F	M+F                      �  TYPE MotorControl :
STRUCT
	ManOn: BOOL := FALSE; (* Visu -> SPS: Antrieb im Handbetrieb ein *)
	ManOff: BOOL := FALSE; (* Visu -> SPS: Antrieb im Handbetrieb aus *)
	EnManCtrl: BOOL := FALSE; (* SPS -> Visu: Freigabe manuelle Steuerung *)
	ActOn: BOOL := FALSE; (* SPS -> Visu: Antrieb eingeschaltet *)
	ActOff: BOOL := FALSE; (* SPS -> Visu: Antrieb ausgeschaltet *)
	Error: BOOL := FALSE; (* SPS -> Visu: St�rung Antrieb *)
END_STRUCT
END_TYPE
             "   , ��e :+           PneumControl M+F	M+F                      �  TYPE PneumControl :
STRUCT
	SetOn: BOOL := FALSE; (* Visu -> SPS: Arbeitsstellung anfahren *)
	SetOff: BOOL := FALSE; (* Visu -> SPS: Grundstellung anfahren *)
	EnSet: BOOL := FALSE; (* SPS -> Visu: Freigabe manuell Steuerung *)
	ActOn: BOOL := FALSE; (* SPS -> Visu: Zylinder in Arbeitsstellung *)
	ActOff: BOOL := FALSE; (* SPS -> Visu: Zylinder in Grundstellung *)
	Error: BOOL := FALSE; (* SPS -> Visu: St�rung Zylinder oder Endschalter *)
END_STRUCT
END_TYPE
             %   , ��� VN        
   PosControl M+F	M+F                   �  TYPE PosControl :
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
                ,  6 ��           StationControl M+F	M+F                      O  TYPE StationControl :
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
              ,   , , : H�           _ASM_FU_SOLLW M+F	M+F      ��������        �   FUNCTION_BLOCK _ASM_FU_SOLLW
VAR_INPUT
	SollW: INT;
	IstW:INT;
	P:INT;
	Pos_Fenster:INT;
END_VAR
VAR_OUTPUT
	SollwReg:INT;
	Vor_Rueck:BOOL;
	Pos_Erreicht:BOOL;
END_VAR
VAR
END_VAR  IF SollW>=IstW THEN
		SollwReg := ( SollW-IstW) *P;
		Vor_Rueck := TRUE;
ELSE
		SollwReg := ( IstW-SollW) *P;
		Vor_Rueck := FALSE;
END_IF

IF ABS( SollW-IstW)<Pos_Fenster THEN
		Pos_Erreicht := TRUE;
ELSE
		Pos_Erreicht := FALSE;
END_IF





               >   , X X �           ClearTestArrays M+F	M+F      ,  d Aah        r  FUNCTION_BLOCK ClearTestArrays
VAR CONSTANT
	ClearArray: ARRAY[0..7] OF INT := 8(0);
END_VAR
VAR_INPUT
	enable: BOOL := FALSE; (* Freigabe *)
END_VAR
VAR_IN_OUT
	Gelenk_I: ARRAY[0..7] OF INT;
	Gelenk_A: ARRAY[0..7] OF INT;
	Vollstaendigkeit: ARRAY[0..7] OF INT;
	Nietung: ARRAY[0..7] OF INT;
	ZZP: ARRAY[0..7] OF INT;
	Huelse: ARRAY[0..7] OF INT;
END_VAR
�   IF enable THEN

	Gelenk_I			:= ClearArray;
	Gelenk_A			:= ClearArray;
	Vollstaendigkeit	:= ClearArray;
	Nietung			:= ClearArray;
	ZZP				:= ClearArray;
	Huelse			:= ClearArray;

END_IF;
               @   , � � @u           ClockDivide  M+F	M+F                      �   FUNCTION_BLOCK ClockDivide
VAR
	clock_old: BOOL;
	counter: INT;
END_VAR
VAR_INPUT
	clock_in: BOOL; (* clock input *)
	n: INT; (* divider *)
END_VAR
VAR_OUTPUT
	clock_out: BOOL;
END_VAR
�   IF n < 1 THEN n := 1;
END_IF;

IF NOT clock_old AND clock_in AND counter <= n THEN
	counter := counter + 1;
END_IF;

IF counter >= n THEN
	clock_out  := NOT clock_out;
	counter := 0;
END_IF;

clock_old := clock_in;               *   ,     W�           ErrMove M+F	M+F      �T  �        �   FUNCTION_BLOCK ErrMove
VAR
	i: INT;
	n: INT;
END_VAR
VAR_INPUT
	ErrArray: ARRAY[0..511] OF BOOL;
END_VAR
VAR_OUTPUT
	ErrWordArray: ARRAY[0..31] OF WORD;
END_VAR
�  FOR i := 0 TO 31 DO
	n := i * 16;
	ErrWordArray[i].0 := ErrArray[n];
	ErrWordArray[i].1 := ErrArray[n+1];
	ErrWordArray[i].2 := ErrArray[n+2];
	ErrWordArray[i].3 := ErrArray[n+3];
	ErrWordArray[i].4 := ErrArray[n+4];
	ErrWordArray[i].5 := ErrArray[n+5];
	ErrWordArray[i].6 := ErrArray[n+6];
	ErrWordArray[i].7 := ErrArray[n+7];
	ErrWordArray[i].8 := ErrArray[n+8];
	ErrWordArray[i].9 := ErrArray[n+9];
	ErrWordArray[i].10 := ErrArray[n+10];
	ErrWordArray[i].11 := ErrArray[n+11];
	ErrWordArray[i].12 := ErrArray[n+12];
	ErrWordArray[i].13 := ErrArray[n+13];
	ErrWordArray[i].14 := ErrArray[n+14];
	ErrWordArray[i].15 := ErrArray[n+15];
END_FOR;               2   , � � ?=           IntScale M+F	M+F        P         �   FUNCTION IntScale : INT
VAR_INPUT
	Int_In: INT; (* Eingangsvariable *)
	Real_Scale: REAL; (* Skalierfaktor *)
	Int_Zero: INT; (* Nullpunkt *)
END_VAR
O   IntScale := REAL_TO_INT ( ( INT_TO_REAL ( Int_In ) * Real_Scale ) ) + Int_Zero;               .   ,   2�           Kettenregister M+F	M+F      ��������        t   FUNCTION_BLOCK Kettenregister
VAR_INPUT

END_VAR
VAR_OUTPUT
END_VAR
VAR

	AKT_KettenTyp_Alt: INT;

END_VAR  
IF AKT_KettenTyp<>AKT_KettenTyp_Alt THEN
	Z_AKT_KettenTyp_Max:=KettenTypen[AKT_KettenTyp,0]-1;
	Ketten_Reg[KettenTypen[AKT_KettenTyp,1]*2]:=KettenTypen[AKT_KettenTyp,2];
	Ketten_Reg[KettenTypen[AKT_KettenTyp,3]*2]:=KettenTypen[AKT_KettenTyp,4];
	Ketten_Reg[KettenTypen[AKT_KettenTyp,5]*2]:=KettenTypen[AKT_KettenTyp,6];
	Ketten_Reg[KettenTypen[AKT_KettenTyp,7]*2]:=KettenTypen[AKT_KettenTyp,8];
	Ketten_Reg[KettenTypen[AKT_KettenTyp,10]*2]:=KettenTypen[AKT_KettenTyp,10];
END_IF
AKT_KettenTyp_Alt:=AKT_KettenTyp;
               #   ,     ��           KS M+F	M+F      ��            FUNCTION_BLOCK KS
VAR_INPUT
	URL_Geschlossen: BOOL; (* Umlenkrolle geschlossen *)
	SpannzylinderGespannt: BOOL; (* Spannzylinder Kettenspeicher gespannt *)
	ActPress: INT; (* Druck-Istwert Spannzylinder *)
	ActPos_ULR: INT; (* Positions-Istwert Umlenkrolle *)
	MinPress: INT; (* minimaler Druck Spannzylinder *)
	MaxPress: INT; (* maximaler Druck Spannzylinder *)
	MinPos_ULR: INT; (* minimale Position Umlenkrolle *)
	MaxPos_ULR: INT; (* maximale Position Umlenkrolle *)
	MaxKapazitaet: INT; (* maximale Kettenspeicher-Kapazit�t in Gliedern *)
	Gliederzahl_InTakt: INT; (* Gliederzahl f�r getaktetes Bef�llen (0 = konstante Geschwindigkeit) *)
	Gliederzahl_OutTakt: INT; (* Gliederzahl f�r getaktete Entnahme (0 = konstante Geschwindigkeit) *)
END_VAR
VAR_OUTPUT
	En_Input: BOOL; (* Freigabe Bef�llen *)
	En_Output: BOOL; (* Freigabe Entnahme *)
	ActState: INT; (* aktueller Zustand f�r Visu *)
END_VAR
VAR
	KS_ready: BOOL; (* Kettenspeicher bereit *)
	ActKapazitaet: INT; (* aktuelle Kettenspeicher-Kapazit�t in Gliedern *)
END_VARG  (* Kettenspeicher betriebsbereit *)

KS_ready := ActPress >= MinPress AND ActPress <= MaxPress AND URL_Geschlossen AND SpannzylinderGespannt;

(* Berechnung der aktuellen Kettenspeicher-Kapazit�t in Gliedern *)

(* ActKapazitaet := LIMIT (MinPos_ULR, MaxPos_ULR - ActPos_ULR, MaxPos_ULR) * MaxKapazitaet / ( MaxPos_ULR - MinPos_ULR ); *)
ActKapazitaet := ( 32767 - LIMIT (MinPos_ULR, ActPos_ULR, MaxPos_ULR) ) * MaxKapazitaet / ( MaxPos_ULR - MinPos_ULR );


(* Freigaben f�r Bef�llen *)

IF Gliederzahl_InTakt = 0 THEN
	IF ActKapazitaet < ( MaxKapazitaet * 3 / 4 ) AND KS_ready THEN
		En_Input := TRUE;					(* Bef�llung mit konstanter Geschwindigkeit: mindestens 25% Kapazit�t im Kettenspeicher frei *)
	END_IF;
	IF ActKapazitaet >= MaxKapazitaet OR NOT KS_ready THEN
		En_Input := FALSE;					(* Kettenspeicher voll *)
	END_IF;
ELSE
	En_Input := ActKapazitaet <= (MaxKapazitaet - Gliederzahl_InTakt) AND KS_ready;		(* getaktete Bef�llung: mindestens 1 Strangl�nge im Kettenspeicher frei *)
END_IF;


(* Freigaben f�r Entnahme *)

IF Gliederzahl_OutTakt = 0 THEN
	IF ActKapazitaet > MaxKapazitaet / 4 AND KS_ready THEN
		En_Output := TRUE;					(* Entnahme mit konstanter Geschwindigkeit: mindestens 25% Kapazit�t im Kettenspeicher belegt *)
	END_IF;
	IF ActKapazitaet <= 0 OR NOT KS_ready THEN
		En_Output := FALSE;					(* Kettenspeicher leer *)
	END_IF;
ELSE
	En_Output := ActKapazitaet >= Gliederzahl_OutTakt AND KS_ready;		(* getaktete Bef�llung: mindestens 1 Strangl�nge im Kettenspeicher belegt *)
END_IF;


(* Freigaben sperren wenn Kettenspeicher nicht bereit (offen oder entspannt oder Druck nicht OK *)

IF NOT KS_ready THEN
	En_Input := FALSE;
	En_Output := FALSE;
END_IF;

(* aktueller Zustand f�r Visu *)

IF KS_ready THEN
	ActState := 1;				(* bereit *)
ELSE
	ActState := 0;				(* St�rung *)
END_IF;               V   ,  R �           Nockenschaltwerk M+F	M+F      ��������        �   PROGRAM Nockenschaltwerk
VAR
	Zeiger :INT:=0;
	Nocke:BOOL:=FALSE;
	Zaeler:WORD;
	Skal_IC_SSI_DG_Input: DINT;
	Skal_IC_SSI_DG_Input_Alt:DINT;
	Skal_IC_SSI_DG_Input_Delta:DINT;
	CTU2:WORD;
END_VAR
�  (*  Miroslav Knezevic TCM 19.03.07  *)
(*  Das Nockenschaltwerk liefert 20 Impulse bei einer Umdrehung des SSI Drehgebers *)
(* Voller Kreis = 8192 Inkremente,  1 Impuls= 20 Inkremente *)



Skal_IC_SSI_DG_Input:=IC_SSI_DG_Input* 20 / 256;
Skal_IC_SSI_DG_Input_Delta:=Skal_IC_SSI_DG_Input - Skal_IC_SSI_DG_Input_Alt;

IF Skal_IC_SSI_DG_Input_Delta<-5 THEN
	Skal_IC_SSI_DG_Input_Delta:=1;
END_IF

IF Skal_IC_SSI_DG_Input_Delta>5 THEN
	Skal_IC_SSI_DG_Input_Delta:=-1;
END_IF

Zeiger_Speicher_Trennstelle:=DINT_TO_INT(Zeiger_Speicher_Trennstelle+Skal_IC_SSI_DG_Input_Delta);
IF Zeiger_Speicher_Trennstelle>500 THEN
	Zeiger_Speicher_Trennstelle:=1;
END_IF
IF Zeiger_Speicher_Trennstelle<1 THEN
	Zeiger_Speicher_Trennstelle:=500;
END_IF

CTU1(
	CU:=M1 ,
	RESET:= ,
	PV:=500 ,
	Q=> ,
	CV=> );

CTU2:=CTU1.CV;


Zeiger_Kette_Trennstelle:=DINT_TO_INT(Zeiger_Kette_Trennstelle+Skal_IC_SSI_DG_Input_Delta);
IF Zeiger_Kette_Trennstelle>Z_AKT_KettenTyp_Max THEN
	Zeiger_Kette_Trennstelle:=1;
END_IF

IF Zeiger_Kette_Trennstelle<1 THEN
	Zeiger_Kette_Trennstelle:=Z_AKT_KettenTyp_Max;
END_IF

IF ABS(Skal_IC_SSI_DG_Input_Delta)>1 THEN
		M1:=TRUE;

END_IF

Skal_IC_SSI_DG_Input_Alt:=Skal_IC_SSI_DG_Input;





               +   ,   ��           OutCtrlB M+F	M+F      q�O           m  FUNCTION_BLOCK OutCtrlB
VAR
	TO_Zyl: TON;
END_VAR
VAR_INPUT
	AutoSet: BOOL := FALSE; (* Ausgang im Automatikbetrieb einschalten *)
	AutoReset: BOOL := FALSE; (* Ausgang im Automatikbetrieb ausschalten *)
	AutoEnable: BOOL := FALSE; (* Ausgangsfreigabe im Auto-Betrieb *)
	ManEnable: BOOL := FALSE; (* Ausgangsfreigabe im Handbetrieb *)
	INI_Home: BOOL := FALSE; (* Initiator Grundstellung *)
	INI_End: BOOL := FALSE; (* Initiator Arbeitsstellung *)
	HoldHome: BOOL := FALSE; (* Ventil in Grundstellung bestromen *)
	HoldEnd: BOOL := FALSE; (* Ventil in Arbeitsstellung bestromen *)
	ResetError: BOOL := FALSE; (* St�rung r�cksetzen *)
	ManualMode: BOOL := FALSE; (* Betriebsart Hand *)
	Timeout: TIME; (* Zeit�berwachung *)
	clock: BOOL := FALSE; (* Takt f�r St�rung *)
END_VAR
VAR_OUTPUT
	OutEnd: BOOL; (* Ausgang Endstellung f�r bistabiles Magnetventil *)
	OutHome: BOOL; (* Ausgang Endstellung f�r bistabiles Magnetventil *)
	EnManControl: BOOL; (* Freigabe Visu-Steuerung Handbetrieb *)
	ActEnd: BOOL; (* aktueller Zustand eingeschaltet *)
	ActHome: BOOL; (* aktueller Zustand ausgeschaltet *)
	VisuErrorState: BOOL; (* St�rmeldung f�r Visu *)
	Error: BOOL; (* St�rung Pneumatikzylinder oder Endschalter *)
END_VAR
VAR_IN_OUT
	ManSet: BOOL; (* Ausgang im Manuellbetrieb einschalten *)
	ManReset: BOOL; (* Ausgang im Manuellbetrieb ausschalten *)
END_VAR
�  IF  ( AutoSet AND AutoEnable ) OR ( ManSet AND ManEnable ) THEN							(* Ausgang Arbeitsstellung einschalten *)
	OutEnd := TRUE;
	OutHome := FALSE;
END_IF;

IF ( NOT AutoEnable AND NOT ManEnable ) OR ( INI_End AND NOT HoldEnd ) OR Error THEN
	OutEnd := FALSE;												(* Ausgang Arbeitsstellung ausschalten *)
END_IF;

IF ( AutoReset AND AutoEnable ) OR ( ManReset AND ManEnable ) THEN						(* Ausgang Grundstellung einschalten *)
	OutHome := TRUE;
	OutEnd := FALSE;
END_IF;

IF ( NOT AutoEnable AND NOT ManEnable ) OR ( INI_Home AND NOT HoldHome ) OR Error THEN
	OutHome := FALSE;												(* Ausgang Grundstellung ausschalten *)
END_IF;


(* Aktueller Zustand *)

ActEnd := INI_End AND NOT INI_Home;
ActHome := INI_Home AND NOT INI_End;

(* St�rung Pneumatikzylinder *)

TO_Zyl ( IN := ( ( OutEnd AND ( INI_Home OR NOT INI_End ) ) OR ( OutHome AND ( INI_End OR NOT INI_Home ) ) OR ( INI_Home AND INI_End )) ,
	 PT := Timeout );
IF TO_Zyl.Q  THEN
	Error := TRUE;
ELSIF ResetError THEN
	Error := FALSE;
END_IF;

(* St�rungsmeldung f�r Visu aktivieren *)

VisuErrorState := Error OR ( clock AND ( ( AutoSet AND NOT INI_End ) OR ( AutoReset AND NOT INI_Home ) ) );

(* Freigabe Visu-Steuerbuttons im Handbetrieb *)

EnManControl := ManualMode AND ManEnable AND NOT Error;

(* Visu-Steuerbuttons f�r Handbetrieb r�cksetzen *)

ManSet := FALSE;
ManReset := FALSE;               )   ,     �        	   OutCtrlKS M+F	M+F      Acom
su        J  FUNCTION_BLOCK OutCtrlKS
VAR
	AutoOn: BOOL := FALSE; (* Ausgang im Auto-Betrieb einschalten *)
	ManOn: BOOL := FALSE; (* Ausgang im Manuell-Betrieb einschalten *)
	TO_Zyl: TON;
END_VAR
VAR_INPUT
	AutoSet: BOOL := FALSE; (* Ausgang im Automatikbetrieb einschalten *)
	AutoReset: BOOL := FALSE; (* Ausgang im Automatikbetrieb ausschalten *)
	AutoEnable: BOOL := FALSE; (* Ausgangsfreigabe f�r Auto-Betrieb *)
	ManEnable: BOOL := FALSE; (* Ausgangsfreigabe f�r Handbetrieb *)
	ErrEnable: BOOL := FALSE; (* Freigabe Fehlerauswertung *)
	INI_Home: BOOL := FALSE; (* Initiator Grundstellung *)
	INI_End: BOOL := FALSE; (* Initiator Arbeitsstellung *)
	ManualMode: BOOL; (* Betriebsart Hand *)
	Timeout: TIME; (* Zeit�berwachung *)
	ResetError: BOOL; (* St�rung r�cksetzen *)
	clock: BOOL := FALSE; (* Takt f�r St�rung *)
END_VAR
VAR_OUTPUT
	Output: BOOL; (* Ausgang f�r monostabiles Magnetventil *)
	EnManControl: BOOL; (* Freigabe Handsteuerung f�r Visu *)
	ActEnd: BOOL; (* aktueller Zustand eingeschaltet *)
	ActHome: BOOL; (* aktueller Zustand ausgeschaltet *)
	VisuErrorState: BOOL; (* Fehlermeldung aktivieren *)
	Error: BOOL; (* St�rung Pneumatikzylinder oder Endschalter *)
END_VAR
VAR_IN_OUT
	ManSet: BOOL; (* Ausgang im Manuellbetrieb einschalten *)
	ManReset: BOOL; (* Ausgang im Manuellbetrieb ausschalten *)
END_VAR
  IF AutoEnable AND NOT ManEnable AND AutoSet AND NOT Error THEN
	AutoOn := TRUE;									(* Ausgang im Auto-Betrieb einschalten *)
END_IF;

IF ManEnable AND ManSet AND NOT Error THEN
	ManOn := TRUE;									(* Ausgang im Handbetrieb einschalten *)
	ManSet := FALSE;
END_IF;

IF NOT AutoEnable OR ( AutoEnable AND ManEnable AND ManReset ) OR AutoReset OR Error THEN
	AutoOn := FALSE;									(* Ausgang im Auto-Betrieb ausschalten *)
END_IF;

IF NOT ManEnable OR ManReset OR Error THEN
	ManOn := FALSE;									(* Ausgang im Handbetrieb ausschalten *)
	ManReset := FALSE;
END_IF;

Output := AutoOn OR ManOn;							(* Ausgang zuweisen *)

(* Aktueller Zustand *)

ActEnd := INI_End AND NOT INI_Home;
ActHome := INI_Home AND NOT INI_End;

(* St�rung Pneumatikzylinder *)

TO_Zyl ( IN := ( ( Output AND ( INI_Home OR NOT INI_End ) ) OR ( NOT Output AND ( INI_End OR NOT INI_Home ) ) ) , PT := Timeout );
IF ErrEnable AND (TO_Zyl.Q OR ( INI_Home AND INI_End )) THEN
	Error := TRUE;
ELSIF ResetError THEN
	Error := FALSE;
END_IF;


(* St�rungsmeldung f�r Visu aktivieren *)

VisuErrorState := Error OR ( clock AND ( ( AutoSet AND NOT INI_End ) OR ( AutoReset AND NOT INI_Home ) ) );


(* Freigabe Visu-Steuerbuttons im Handbetrieb *)

EnManControl := ManualMode AND NOT Error;               1   ,     q�           OutCtrlM M+F	M+F      ��(-          I  FUNCTION_BLOCK OutCtrlM
VAR
	AutoOn: BOOL := FALSE; (* Ausgang im Auto-Betrieb einschalten *)
	ManOn: BOOL := FALSE; (* Ausgang im Manuell-Betrieb einschalten *)
	TO_Zyl: TON;
END_VAR
VAR_INPUT
	AutoSet: BOOL := FALSE; (* Ausgang im Automatikbetrieb einschalten *)
	AutoReset: BOOL := FALSE; (* Ausgang im Automatikbetrieb ausschalten *)
	AutoEnable: BOOL := FALSE; (* Ausgangsfreigabe f�r Auto-Betrieb *)
	ManEnable: BOOL := FALSE; (* Ausgangsfreigabe f�r Handbetrieb *)
	ErrEnable: BOOL := FALSE; (* Freigabe Fehlerauswertung *)
	INI_Home: BOOL := FALSE; (* Initiator Grundstellung *)
	INI_End: BOOL := FALSE; (* Initiator Arbeitsstellung *)
	ManualMode: BOOL; (* Betriebsart Hand *)
	Timeout: TIME; (* Zeit�berwachung *)
	ResetError: BOOL; (* St�rung r�cksetzen *)
	clock: BOOL := FALSE; (* Takt f�r St�rung *)
END_VAR
VAR_OUTPUT
	Output: BOOL; (* Ausgang f�r monostabiles Magnetventil *)
	EnManControl: BOOL; (* Freigabe Handsteuerung f�r Visu *)
	ActEnd: BOOL; (* aktueller Zustand eingeschaltet *)
	ActHome: BOOL; (* aktueller Zustand ausgeschaltet *)
	VisuErrorState: BOOL; (* Fehlermeldung aktivieren *)
	Error: BOOL; (* St�rung Pneumatikzylinder oder Endschalter *)
END_VAR
VAR_IN_OUT
	ManSet: BOOL; (* Ausgang im Manuellbetrieb einschalten *)
	ManReset: BOOL; (* Ausgang im Manuellbetrieb ausschalten *)
END_VAR
  IF AutoEnable  AND AutoSet AND NOT Error THEN
	AutoOn := TRUE;									(* Ausgang im Auto-Betrieb einschalten *)
END_IF;

IF ManEnable AND ManSet AND NOT Error THEN
	ManOn := TRUE;									(* Ausgang im Handbetrieb einschalten *)
	ManSet := FALSE;
END_IF;

IF NOT AutoEnable OR ( AutoEnable AND ManEnable AND ManReset ) OR AutoReset OR Error THEN
	AutoOn := FALSE;									(* Ausgang im Auto-Betrieb ausschalten *)
END_IF;

IF NOT ManEnable OR ManReset OR Error THEN
	ManOn := FALSE;									(* Ausgang im Handbetrieb ausschalten *)
	ManReset := FALSE;
END_IF;

Output := AutoOn OR ManOn;							(* Ausgang zuweisen *)

(* Aktueller Zustand *)

ActEnd := INI_End AND NOT INI_Home;
ActHome := INI_Home AND NOT INI_End;

(* St�rung Pneumatikzylinder *)

TO_Zyl ( IN := ( ( Output AND ( INI_Home OR NOT INI_End ) ) OR ( NOT Output AND ( INI_End OR NOT INI_Home ) ) ) , PT := Timeout );
IF ErrEnable AND (TO_Zyl.Q OR ( INI_Home AND INI_End )) THEN
	Error := TRUE;
ELSIF ResetError THEN
	Error := FALSE;
END_IF;


(* St�rungsmeldung f�r Visu aktivieren *)

VisuErrorState := Error OR ( clock AND ( ( AutoSet AND NOT INI_End ) OR ( AutoReset AND NOT INI_Home ) ) );


(* Freigabe Visu-Steuerbuttons im Handbetrieb *)

EnManControl := ManualMode AND NOT Error;               0   ,     �        
   ServoKette M+F	M+F        	            FUNCTION_BLOCK ServoKette
VAR

	TOF_RFR: TOF; (* Ausschaltverz�gerung Reglerfreigabe *)
END_VAR
VAR_INPUT
	AutoStartPos: BOOL := FALSE; (* Automatikbetrieb Positionierung starten *)
	ManFwd: BOOL := FALSE; (* Handbetrieb vorw�rts *)
	ManBwd: BOOL := FALSE; (* Handbetrieb r�ckw�rts *)
	ManualMode: BOOL := FALSE; (* Betriebsart Manuell *)
	NotAusOK: BOOL := FALSE; (* Not-Aus OK *)
	DriveError: BOOL := FALSE; (* Antriebsst�rung *)
	Servo_Ready: BOOL := FALSE; (* Antrieb bereit *)
	RefError: BOOL := FALSE; (* St�rung Referenzierung *)
	PosError: BOOL := FALSE; (* St�rung Positionierung *)
	ResetError: BOOL := FALSE; (* St�rung r�cksetzen *)
	Clock: BOOL := FALSE; (* Takt f�r Fehler *)
END_VAR
VAR_OUTPUT
	Servo_RFR: BOOL := FALSE; (* Servoumrichter Reglerfreigabe *)
	Servo_CINH: BOOL := FALSE; (* Servoumrichter Reglersperre �ber CAN-Bus *)
	ServoManFwd: BOOL := FALSE; (* Servoantrieb manuell vorw�rts *)
	ServoManBwd: BOOL := FALSE; (* Servoantrieb manuell r�ckw�rts *)
	ServoStartPos: BOOL := FALSE; (* Servoantrieb Positionierung starten *)
	ServoTripReset: BOOL := FALSE; (* Servoumrichter St�rung r�cksetzen *)
	ServoResetError: BOOL := FALSE; (* Servoumrichter St�rung Ref/Pos zur�cksetzen *)
	EnManCtrl: BOOL := FALSE; (* Freigabe manuelle Steuerung *)
	Visu_DriveOn: BOOL := FALSE; (* Visu: Antrieb eingeschaltet *)
	Visu_DriveOff: BOOL := FALSE; (* Visu: Antrieb ausgeschaltet *)
	Visu_Error: BOOL := FALSE; (* Visu: St�rung Antrieb *)
	Error: BOOL := FALSE; (* Sammelst�rung Antrieb *)
END_VAR    St�rung Antrieb �Servo_ReadyRefErrorPosErrorA
DriveErrorOR  ErrorAClockAND  
Visu_Error   Ausgang Reglerfreigabe �ErrorANotAusOKAND  	Servo_RFR   Antrieb ein f�r Visu TOF_RFRAutoStartPosBManFwdAManBwdORA
ManualModeANDORAT#1.2sTOF       A	Servo_RFRAND  Visu_DriveOn   Ausgang Reglersperre �	Servo_RFR  
Servo_CINH   Ausgang manuell vorw�rts ManFwdA	Servo_RFRAND  ServoManFwd   Ausgang manuell r�ckw�rts ManBwdA	Servo_RFRAND  ServoManBwd#   Ausgang Auto-Positionierung starten AutoStartPosA	Servo_RFRAND  ServoStartPos   Ausgang Trip Reset 
DriveErrorA
ResetErrorAND  ServoTripReset"   Ausgang St�rung Ref/Pos r�cksetzen RefErrorAPosErrorORA
ResetErrorAND  ServoResetError+   Freigabe f�r Visu-Steuerbuttons Handbetrieb 
ManualMode�ErrorAND  	EnManCtrl   Visu: Antrieb ausgeschaltet �	Servo_RFR�ErrorAND  Visu_DriveOffd                  /   , B B �           State M+F	M+F                  �   FUNCTION State : INT
VAR_INPUT
	error: BOOL := FALSE; (* St�rung *)
	busy: BOOL := FALSE; (* Station aktiv *)
	finished: BOOL := FALSE; (* Station fertig *)
END_VAR
  IF NOT error AND NOT busy THEN
	IF finished THEN
		State := 3;							(* Station fertig *)
	ELSE
		State := 1;							(* Station bereit *)
	END_IF;
ELSIF busy AND NOT error THEN
	State := 2;								(* Station aktiv *)
ELSE
	State := 0;								(* St�rung *)
END_IF;                 ����, B B �         "   STANDARD.LIB 5.6.98 12:03:02 @V�w5      CONCAT @                	   CTD @        	   CTU @        
   CTUD @           DELETE @           F_TRIG @        
   FIND @           INSERT @        
   LEFT @        	   LEN @        	   MID @           R_TRIG @           REPLACE @           RIGHT @           RS @        
   SEMA @           SR @        	   TOF @        	   TON @           TP @              Global Variables 0 @                        , , , ��          d                �{�{�{�{�{�{�{�{  
             ����   ��,            ����, � � �z                   	   Bausteine            
   Funktionen                 IntScale  2                   State  /   ����              Funktionsbausteine
                 _ASM_FU_SOLLW  ,                   ClearTestArrays  >                   ClockDivide  @                   ErrMove  *                   Kettenregister  .                   KS  #                   OutCtrlB  +                	   OutCtrlKS  )                   OutCtrlM  1                
   ServoKette  0   ����               Nockenschaltwerk  V   ����           
   Datentypen                 DriveControl  $                	   KettenTyp  (               
   KS_Control  !                   MotorControl  -                   PneumControl  "                
   PosControl  %                   StationControl     ����             Visualisierungen  ����              Globale Variablen                Globale_Variablen  4                   Variable_Configuration  	                   Variablen_Konfiguration  '   ����                                           % h�             ��@                         	   localhost            P      	   localhost            P      	   localhost            P           M�