#include "LimitingFlags.h"

LimitingFlags::LimitingFlags() {}

LimitingFlags::~LimitingFlags() {}

std::string LimitingFlags::toString() {
    std::string str = "Limiting Flags:\n";
    str += "hainComputing: " + std::to_string(hainComputing) + ";\n";
    str += "\teps_arg: " + std::to_string(eps_arg) + ";\n";
    str += "\teps_f: " + std::to_string(eps_f) + ";\n";
    str += "\tm: " + std::to_string(m) + ";\n";
    return str;
}

LimitingFlags LimitingFlags::clone() {
    LimitingFlags flags;
    flags.hainComputing = hainComputing;
    flags.eps_f = eps_f;
    flags.eps_arg = eps_arg;
    flags.m = m;
    return flags;
}