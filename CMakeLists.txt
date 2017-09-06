cmake_minimum_required(VERSION 3.8)
project(progOptMet)

set(CMAKE_CXX_STANDARD 11)

set(SOURCE_FILES library.cpp library.h main.cpp)
add_executable(progOptMet ${SOURCE_FILES})