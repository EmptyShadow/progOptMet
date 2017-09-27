#include "Dichotomy.h"

Dichotomy::Dichotomy() {
    name = "Dichotomy";
}

Dichotomy::~Dichotomy() {}

int Dichotomy::run(Params &params) {
    params.writelnInLogs("Start method Dichotomy\n");
    params.writelnInLogs(params.input.toString());
    if (params.input.intervalPoints.size() < 2) {
        params.writelnInErrs("Error: input interval minimization;\n");
        return 1;
    }
    double delta = 0.1 * params.input.eps_arg, a_k = params.input.intervalPoints[0], b_k = params.input.intervalPoints[1];
    double (*f)(double) = params.input.f;
    double lambda_k, mu_k;
    int k = 0;
    while(true) {
        k++;
        lambda_k = (b_k + a_k - delta) / 2.0;
        mu_k = (b_k + a_k + delta) / 2.0;
        if (f(lambda_k) < f(mu_k)) {
            b_k = mu_k;
        } else {
            a_k = lambda_k;
        }
        if (params.flags.m) {
            if (k > params.input.m) {
                break;
            }
        }
        if (params.flags.eps_arg) {
            if (abs(b_k - a_k) <= params.input.eps_arg) {
                break;
            }
        }
        if (params.flags.eps_f) {
            if (abs(f(b_k) - f(a_k)) <= params.input.eps_arg) {
                break;
            }
        }
    }
    double x_ = (b_k + a_k) / 2.0, f_ = f(x_);
    params.output.k = k;
    params.output.x_  = x_;
    params.output.f_x_ = f(x_);
    params.output.intervalPoints.clear();
    params.output.intervalPoints.push_back(a_k);
    params.output.intervalPoints.push_back(b_k);
    if (params.flags.hainComputing) {
        params.input.intervalPoints.clear();
        params.input.intervalPoints.push_back(a_k);
        params.input.intervalPoints.push_back(b_k);
        params.input.x1 = x_;
    }

    params.writelnInLogs(params.output.toString());
    params.writelnInLogs("End method Dichotomy\n\n");
    return 0;
}