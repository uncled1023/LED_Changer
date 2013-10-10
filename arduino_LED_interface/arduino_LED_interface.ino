//Developed by Rajarshi Roy
int red, green, blue; //red, green and blue values
int RedPin = 10; //Red: PWM pin 10
int GreenPin = 9; //Green: PWM pin 11
int BluePin = 11; //Blue: PWM pin 9
void setup()
{
	Serial.begin(9600);
	//initial values (no significance)
	int red = 255;
	int blue = 255;
	int green = 255;
}

void loop()
{
	//protocol expects data in format of 4 bytes
	//(xff) as a marker to ensure proper synchronization always
	//followed by red, green, blue bytes
	if (Serial.available()>=4)
	{
		if(Serial.read() == 0xff)
		{
			red = Serial.read();
			green= Serial.read();
			blue = Serial.read();
		}
	}
	//finally control led brightness through pulse-width modulation
	analogWrite (RedPin, red);
	analogWrite (GreenPin, green);
	analogWrite (BluePin, blue);
	delay(10); //just to be safe
}