function [rbDerivative] = evaluate(initial, derivative, var, deltaTime)
  tmp = initial;
  tmp.Position.x += derivative.Position.x * deltaTime;
  tmp.Position.y += derivative.Position.y * deltaTime;
  tmp.Position.z += derivative.Position.z * deltaTime;
  tmp.Velocity.x += derivative.Velocity.x * deltaTime;
  tmp.Velocity.y += derivative.Velocity.y * deltaTime;
  tmp.Velocity.z += derivative.Velocity.z * deltaTime;
  
  rbDerivative.Position.x = tmp.Velocity.x;
  rbDerivative.Position.y = tmp.Velocity.y;
  rbDerivative.Position.z = tmp.Velocity.z;
  
  drag = 0.5 * tmp.DragCoefficient * tmp.Area * var.AirDensity * velocitySquared / tmp.Mass;
  rbDerivative.Position.x = 0.5 * tmp.DragCoefficient * var.AirDensity *;
  rbDerivative.Position.y = var.Gravity.y;
  rbDerivative.Position.z = var.Gravity.z;
end

function [newRb] = nextPoint(rb, k1, k2, k3, k4, deltaTime)
  newRb = rb;
  newRb.Position.x =  rb.Position.x + deltaTime / 6 * (k1.Position.x + 2 * k2.Position.x + 2 * k3.Position.x + k4.Position.x);
  newRb.Position.y =  rb.Position.y + deltaTime / 6 * (k1.Position.y + 2 * k2.Position.y + 2 * k3.Position.y + k4.Position.y);
  newRb.Position.z =  rb.Position.z + deltaTime / 6 * (k1.Position.z + 2 * k2.Position.z + 2 * k3.Position.z + k4.Position.z);
  
  newRb.Velocity.x =  rb.Velocity.x + deltaTime / 6 * (k1.Velocity.x + 2 * k2.Velocity.x + 2 * k3.Velocity.x + k4.Velocity.x);
  newRb.Velocity.y =  rb.Velocity.y + deltaTime / 6 * (k1.Velocity.y + 2 * k2.Velocity.y + 2 * k3.Velocity.y + k4.Velocity.y);
  newRb.Velocity.z =  rb.Velocity.z + deltaTime / 6 * (k1.Velocity.z + 2 * k2.Velocity.z + 2 * k3.Velocity.z + k4.Velocity.z);
end

function [newRb] = actualPoint(initial, var, time)
  newRb.Position.x = initial.Position.x + initial.Velocity.x * time + 0.5 * var.Gravity.x * time * time;
  newRb.Position.x = initial.Position.x + initial.Velocity.y * time + 0.5 * var.Gravity.y * time * time;
  newRb.Position.x = initial.Position.x + initial.Velocity.z * time + 0.5 * var.Gravity.z * time * time;
  
  newRb.Velocity.x = initial.Velocity.x + var.Gravity.x * time;
  newRb.Velocity.y = initial.Velocity.y + var.Gravity.y * time;
  newRb.Velocity.z = initial.Velocity.z + var.Gravity.z * time;
end