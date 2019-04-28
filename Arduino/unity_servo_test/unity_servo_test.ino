#include <Servo.h>

double zero_offset = 50;
double finish_point = 90;
// サーボのピン番号
const int SERVO_PIN = 9;
// サーボのインスタンス
Servo servo;
// INITがtrueの時は、モーターの位置を0にするだけ
const bool INIT = false;
void setup() {
  // put your setup code here, to run once:
  servo.attach(SERVO_PIN);
    Serial.begin(9600);
  servo.write(zero_offset);
  pinMode(13, OUTPUT);
}
void loop() {
  // put your main code here, to run repeatedly:
  if (INIT) return;
  String str;
  double distance;
  if (Serial.available() > 0)
  {
    //digitalWrite(13, HIGH);
    str = Serial.readStringUntil(',');
    distance = str.toDouble();
    if (distance > 0.15) {
      servo.write(zero_offset);
    } else{//(distance <= 0.15) {
      double angle;
      angle = zero_offset + (finish_point - zero_offset) * (0.15 - distance) / 0.02;
      if(finish_point < angle ){
        angle = finish_point;
      }
      servo.write(angle);
      digitalWrite(13, HIGH);

    }
  }
  //digitalWrite(13, HIGH);

  
    servo.write(zero_offset);
    delay(2000);
    servo.write(finish_point);
    delay(2000);
}
