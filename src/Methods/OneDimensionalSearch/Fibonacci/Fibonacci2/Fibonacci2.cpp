#include "Fibonacci2.h"

Fibonacci2::Fibonacci2() {
    name = "Fibonacci 2";
}

Fibonacci2::~Fibonacci2() {}

int Fibonacci2::run(Params &params) {
    params.writelnInLogs("Start method Fibonacci 2\n");
    params.writelnInLogs(params.input.toString());
    if (params.input.intervalPoints.size() < 2) {
        params.writelnInErrs("Error: input interval minimization;\n");
        return 1;
    }

    double a1 = params.input.intervalPoints[0], b1 = params.input.intervalPoints[1], Ln = params.input.eps_arg;
    double (*f)(double) = params.input.f;
    int n;
    double Fn = getNextNumber(abs(a1 - b1) / Ln, n), Fnm = getNNumber(n - 1);
    int chet = n % 2 ? -1 : 1;
    double x1 = a1 + Fnm * abs(b1 - a1) / Fn + chet * Ln / Fn, x2,
            f1, f2;
    int k = 1;
    do {
        x2 = a1 + b1 - x1;
        f1 = f(x1);
        f2 = f(x2);
        if (x1 < x2 && f1 < f2) {
            b1 = x2;
        } else if (x1 < x2 && f1 > f2) {
            a1 = x1;
            x1 = x2;
        } else if (x1 > x2 && f1 < f2) {
            a1 = x2;
        } else if (x1 > x2 && f1 > f2) {
            b1 = x1;
            x1 = x2;
        }
        k++;
        if (params.flags.m) {
            if (k > params.input.m) {
                break;
            }
        }
        if (params.flags.eps_arg) {
            if (abs(b1 - a1) <= params.input.eps_arg) {
                break;
            }
        }
        if (params.flags.eps_f) {
            if (abs(f(b1) - f(a1)) <= params.input.eps_arg) {
                break;
            }
        }
    } while (k < n);

    params.output.k = k;
    params.output.x_  = x1;
    params.output.f_x_ = f(x1);
    params.output.intervalPoints.clear();
    params.output.intervalPoints.push_back(a1);
    params.output.intervalPoints.push_back(b1);
    if (params.flags.hainComputing) {
        params.input.intervalPoints.clear();
        params.input.intervalPoints.push_back(a1);
        params.input.intervalPoints.push_back(b1);
        params.input.x1 = x1;
    }

    params.writelnInLogs(params.output.toString());
    params.writelnInLogs("End method Fibonacci 2\n\n");

    return 0;
}