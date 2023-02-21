float4 _ColorArray[4];
float _MinArray[4];
float _MaxArray[4];

void Select_float(in float value, out float4 Color) {
	for (int i = 0; i < 4; ++i)
	{
		float min = _MinArray[i];
		float max = _MaxArray[i];
		Color += _ColorArray[i] * step(min, value) * (1 - step(max, value));
	}
}
