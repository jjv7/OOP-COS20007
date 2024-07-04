#include <stdio.h>

float Average (int *numbers, int length) {
    int i;
    int sum = 0;
    for (i = 0; i < length; i++) {
        sum = sum + numbers[i];
    }
    
    float average = (float) sum / length;
    return average;
}


int main() {
    int numbers[] = {1, 2, 3, 4, 5, 6};                           // Array for demonstration purposes
    int length = sizeof(numbers) / sizeof(numbers[0]);
    float average = Average(numbers, length);
    printf("Average = %f\n", average);
    if (average >= 10) {
        printf("Double digits\n");
    } else if (average >= 0 && average < 10) {
        printf("Single digits\n");
    } else {
        printf("Average value is in the negative\n");
    }
    return 0;
}