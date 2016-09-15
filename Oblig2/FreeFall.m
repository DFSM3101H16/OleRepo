function [rbDerivative] = evaluate(initial, derivative, var, deltaTime)
  tmp = initial;
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

function [newRb] = actualPoint(initial, var, time)
  newRb.Position = initial.Position + initial.Velocity * time + 0.5 * var.Gravity * time * time;
  
  newRb.Velocity = initial.Velocity + var.Gravity * time;
  newRb.Velocity = initial.Velocity + var.Gravity * time;
  newRb.Velocity = initial.Velocity + var.Gravity * time;
end