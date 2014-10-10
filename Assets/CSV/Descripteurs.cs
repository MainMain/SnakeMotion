using UnityEngine;
using System.Collections;

public class Descripteurs : MonoBehaviour {

	private float _vitesseMoy;
	private float _vitesseMax;
	private float _vitesseMin;
	private float _distMax;
	private float _distMin;
	private float _distTot;
	private float _time;
	private double _amplitudeMax;
	private double _amplitudeMin;
	private float _nbAllerRetour;
	private float _nbPoing;
	private float _accelMax;
	private bool _isOneHand;
	private CsvExport m_export;

	public Descripteurs(){
		m_export = new CsvExport();
		_amplitudeMin = 300;
		_amplitudeMax = 0;
		_nbPoing = 0;
		_vitesseMax = 0;
		_vitesseMin = 0;
		_vitesseMoy = 0;
		_distMax = 0;
		_distMin = 0;
	}

	public void SaveExport(string game){
		m_export.AddRow();
		m_export["Amplitude Max en mm"] = _amplitudeMax;
		m_export["Amplitude Min en mm"] = _amplitudeMin;
		m_export["Vitesse Max en m/s"] = _vitesseMax;
		m_export["Vitesse Min en m/s"] = _vitesseMin;
		m_export["Vitesse Moy en m/s"] = _vitesseMoy;
		m_export["Nb poing"] = _nbPoing;
		System.IO.Directory.CreateDirectory(Application.dataPath+@"\ExportDataCSV\Descripteur");
		m_export.ExportToFile(Application.dataPath+@"\ExportDataCSV\Descripteur\descripteurs_"+game+System.DateTime.Now.ToString("dd.MM.yyyy-HH.mm.ss")+".csv");
	}

	public void AmplitudeMinMax(double valuePos){
		if(valuePos >= _amplitudeMax){
			_amplitudeMax = valuePos;
		}
		if(valuePos <= _amplitudeMin){
			_amplitudeMin = valuePos;
		}
	}

	public void NombrePoing(){
		_nbPoing++;
	}

	public void CalcVitesse(float time, float value){
		_time = time;
		if(value >= _distMax){
			_distMax = value;
		}
		if(value <= _distMin){
			_distMin = value;
		}
		_vitesseMax = (_distMax/0.02f)/1000 ;
		_vitesseMin = (_distMin/0.02f)/1000;
		_distTot += value;
		_vitesseMoy = (_distTot/_time)/1000;
	}

}
