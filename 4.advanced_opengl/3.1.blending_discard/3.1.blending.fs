#version 330 core
out vec4 FragColor;

in vec2 TexCoords;

uniform sampler2D texture1;

void main()
{             
    vec4 texColor = texture(texture1, TexCoords);
    if(texColor.a < 0.1)
        discard;
        //GLSL给了我们discard命令，一旦被调用，它就会保证片段不会被进一步处理， 否则出现白边
    FragColor = texColor;
}