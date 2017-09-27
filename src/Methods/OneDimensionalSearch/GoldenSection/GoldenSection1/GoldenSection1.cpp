#include "GoldenSection1.h"

GoldenSection1::GoldenSection1() {
    name = "Golden section 1";
}

GoldenSection1::~GoldenSection1() {}

int GoldenSection1::run(Params &params) {
    params.writelnInLogs("Start method golden section 1\n");
    params.writelnInLogs(params.input.toString());
    if (params.input.intervalPoints.size() < 2) {
        params.writelnInErrs("Error: input interval minimization;\n");
        return 1;
    }
    // задание начальных данных по полученным
    double a1 = params.input.intervalPoints[0], b1 = params.input.intervalPoints[1];
    double (*f)(double) = params.input.f;
    // начальный этап
    double lambda = lambdaGoldenSection(a1, b1),
            mu = muGoldenSection(a1, b1);
    int k = 1;
    // основной этап
    // Сокращение текущего интервала локализации
    while (true) {
        if (f(a1) < f(b1)) {
            b1 = mu;
            mu = lambda;
            lambda = lambdaGoldenSection(a1, b1);
        } else {
            a1 = lambda;
            lambda = mu;
            mu = muGoldenSection(a1, b1);
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
    }

    double x_ = (a1 + b1) / 2.0, f_ = f(x_);

    params.output.k = k;
    params.output.x_  = x_;
    params.output.f_x_ = f(x_);
    params.output.intervalPoints.clear();
    params.output.intervalPoints.push_back(a1);
    params.output.intervalPoints.push_back(b1);
    if (params.flags.hainComputing) {
        params.input.intervalPoints.clear();
        params.input.intervalPoints.push_back(a1);
        params.input.intervalPoints.push_back(b1);
        params.input.x1 = x_;
    }

    params.writelnInLogs(params.output.toString());
    params.writelnInLogs("End method golden section 1\n\n");

    return 0;
}