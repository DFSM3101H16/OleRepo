clear
close all

rigidbody.Position = [0;0;0];
rigidbody.Velocity = [3;20;0];

Physics.Gravity = [0;-9.81;0];

Time.Step = 1;
Time.Duration = 6;
DataPoints = Time.Duration / Time.Step;


function [rbDerivative] = evaluate(initialValue, derivative, var, deltaTime)
  tmp = initialValue;
  tmp.Position += derivative.Position * deltaTime;
  tmp.Velocity += derivative.Velocity * deltaTime;
  
  rbDerivative.Position = tmp.Velocity;
  rbDerivative.Velocity = var.Gravity;
end

function [newRb] = nextPoint(rb, k1, k2, k3, k4, deltaTime)
  newRb = rb;
  newRb.Position =  rb.Position + deltaTime / 6 * (k1.Position + 2 * k2.Position + 2 * k3.Position + k4.Position);
  
  newRb.Velocity =  rb.Velocity + deltaTime / 6 * (k1.Velocity + 2 * k2.Velocity + 2 * k3.Velocity + k4.Velocity);
end

function [newRb] = actualPoint(initialValue, var, time)
  newRb.Position = initialValue.Position + initialValue.Velocity * time + 0.5 * var.Gravity * time * time;
  
  newRb.Velocity = initialValue.Velocity + var.Gravity * time;
end

times = linspace(0, Time.Duration, DataPoints);
result = cell(DataPoints, 1);
resultX = zeros(DataPoints, 1);
resultY = zeros(DataPoints, 1);
result{1} = rigidbody;
resultX(1) = rigidbody.Position(1);
resultY(1) = rigidbody.Position(2);

actualX = zeros(DataPoints, 1);
actualY = zeros(DataPoints, 1);
actualX(1) = rigidbody.Position(1);
actualY(1) = rigidbody.Position(2);

for i = 2:DataPoints
  tmp = RK4(result{i - 1}, Physics, Time.Step, @evaluate, @nextPoint);
  result{i} = tmp;
  resultX(i) = tmp.Position(1);
  resultY(i) = tmp.Position(2);
  
  tmp2 = actualPoint(rigidbody, Physics, Time.Step * (i - 1));
  actualX(i) = tmp.Position(1);
  actualY(i) = tmp.Position(2);
endfor

error = (actualX - resultX) + (actualY - resultY);

%plot(resultX, resultY, actualX, actualY, "color", [1, 0, 0]);
plot(times, error);