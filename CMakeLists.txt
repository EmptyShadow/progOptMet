cmake_minimum_required(VERSION 3.8)
project(progOptMet)

set(CMAKE_CXX_STANDARD 11)

set(SOURCE_FILES src/library.cpp src/library.h
        main.cpp
        src/Parameters/Params.cpp src/Parameters/Params.h
        src/Parameters/Input/InputParams.cpp src/Parameters/Input/InputParams.h
        src/Parameters/Output/OutputParams.cpp src/Parameters/Output/OutputParams.h
        src/Parameters/Flags/LimitingFlags.cpp src/Parameters/Flags/LimitingFlags.h
        src/Methods/Method.cpp src/Methods/Method.h
        src/Methods/OneDimensionalSearch/Swenn/Swenn.cpp src/Methods/OneDimensionalSearch/Swenn/Swenn.h
        src/Methods/Composer/ComposerMethods.cpp src/Methods/Composer/ComposerMethods.h
        src/Methods/OneDimensionalSearch/GoldenSection/GoldenNumbers.cpp src/Methods/OneDimensionalSearch/GoldenSection/GoldenNumbers.h
        src/Methods/OneDimensionalSearch/GoldenSection/GoldenSection1/GoldenSection1.cpp src/Methods/OneDimensionalSearch/GoldenSection/GoldenSection1/GoldenSection1.h
        src/Methods/OneDimensionalSearch/GoldenSection/GoldenSection2/GoldenSection2.cpp src/Methods/OneDimensionalSearch/GoldenSection/GoldenSection2/GoldenSection2.h
        src/Methods/OneDimensionalSearch/Dichotomy/Dichotomy.cpp src/Methods/OneDimensionalSearch/Dichotomy/Dichotomy.h
        src/Methods/OneDimensionalSearch/Fibonacci/FibonacciNumbers.cpp src/Methods/OneDimensionalSearch/Fibonacci/FibonacciNumbers.h
        src/Methods/OneDimensionalSearch/Fibonacci/Fibonacci1/Fibonacci1.cpp src/Methods/OneDimensionalSearch/Fibonacci/Fibonacci1/Fibonacci1.h
        src/Methods/OneDimensionalSearch/Fibonacci/Fibonacci2/Fibonacci2.cpp src/Methods/OneDimensionalSearch/Fibonacci/Fibonacci2/Fibonacci2.h
        src/Core.cpp src/Core.h
        src/Parameters/Vars/Vector.cpp src/Parameters/Vars/Vector.h
        src/Func/Func.cpp src/Func/Func.h
        src/Parser/MathParser.cpp src/Parser/MathParser.h
        src/Parser/Result.cpp src/Parser/Result.h
        )
add_executable(progOptMet ${SOURCE_FILES})