using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class		GameInfo{

	public static bool battle = false;
	public static Vector3 battledoggopos;
	// public static bool battle = false;
	public static int	stage = 0;
	// public static bool stageSet = false;

	public static float	health = 10;

	public static float BattleHealth = 10;

	public static float	power = 10;

	public static float	fatigue = 0;
	public static int	animspeed = 1;
	
	public static float	food = 100;
	
	public static float	specialgauge = 0;

	public static float maxennemyhp = 1f;
	public static float currentennemyhp = 1f;
	
	public static float[] ennemyLifeTab = new float[] {500f, 5000f, 100000f, 500000f, 5000000f, 50000000000f};
	public static float[] ennemypowerTab = new float[] {50f, 500f, 10000f, 50000f, 500000f, 50000000f};
	public static float[] ennemyspeedTab = new float[] {5f, 4f, 3f, 2f, 1f, 0.5f};


	public static bool doggolost = false;
	public static int loosecanvasnumber = 0;
	public static bool looseactivatenextcanvas = true;
	public static bool loosecanvasactivated = false;

	public static bool activatenextcanvas = true;
	public static bool canvasactivated = false;
	public static int	canvasnumber = 0;

	public static int[] canvasperstage = new int[]{3, 7, 13, 17}; 
}
