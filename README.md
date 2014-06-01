SuccessiveApproximationGUI
==========================

Analog to Digital conversion via GUI for successive approximation.

Successive Approximation Overview:
  Successive Approximation is a method to convert an analog signal to digital bits with the most efficiency. This involves
  multiplying the step-size (R) of the inputs (Vref/(2^N) where Vref is the reference voltage and N is the number of bits)
  by the decimal value of the bits. First, make the first bit (MSB) a '1' and convert the binary byte(s) to their decimal     form, then multiply it by R. If that value is above the desired voltage (Vin), then make the first bit a '0'. Then move
  onto the next bit and repeat the process. After N interations, the program will convert the analog signal into a digital
  output.
  
Note:
  Attached files are the layout file, and the source code files. Not all files were included.
