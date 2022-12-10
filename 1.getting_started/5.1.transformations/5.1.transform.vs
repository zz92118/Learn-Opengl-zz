#version 330 core
layout (location = 0) in vec3 aPos;
layout (location = 1) in vec2 aTexCoord;

out vec2 TexCoord;

uniform mat4 transform; //uniform 全局变量

void main()
{
	gl_Position = transform * vec4(aPos, 1.0); //在源文件中可以操作
	TexCoord = vec2(aTexCoord.x, aTexCoord.y);
}