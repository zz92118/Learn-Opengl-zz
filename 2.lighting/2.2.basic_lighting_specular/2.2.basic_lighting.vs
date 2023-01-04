// vertex shader
#version 330 core
layout (location = 0) in vec3 aPos;
layout (location = 1) in vec3 aNormal;

out vec3 FragPos;
out vec3 Normal; //法线的计算写在 vertex shader里面了 ，这个需要用来计算difuss和specular的反射光

//法线的不具备MVP变换不变性 必须要重新计算法线向量

uniform mat4 model;
uniform mat4 view;
uniform mat4 projection;

void main()
{
    FragPos = vec3(model * vec4(aPos, 1.0)); //帧的位置 只需要*model矩阵
    Normal = mat3(transpose(inverse(model))) * aNormal;  
    
    gl_Position = projection * view * vec4(FragPos, 1.0);
}
