function [newRb] = RK4(rb, var, deltaTime, f, nextPoint)
  k1 = f(rb, rb, var, 0);
  k2 = f(rb, k1, var, 0.5 * deltaTime);
  k3 = f(rb, k2, var, 0.5 * deltaTime);
  k4 = f(rb, k3, var, 1 * deltaTime);
  
  newRb = nextPoint(rb, k1, k2, k3, k4, deltaTime);
end

function [newRb] = Euler(rb, var, deltaTime, evaluate, nextPoint)
  k1 = evaluate(rb, rb, var, deltaTime);
  newRb = nextPoint(rb, k1, k1, k1, k1, deltaTime);
end