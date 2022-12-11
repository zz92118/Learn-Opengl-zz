#version 330 core
out vec4 FragColor;

struct Material {
    vec3 ambient;
    vec3 diffuse;
    vec3 specular;    
    float shininess;
}; 

struct Light {
    vec3 position;

    vec3 ambient;
    vec3 diffuse;
    vec3 specular;
};

in vec3 FragPos;  
in vec3 Normal;  
  
uniform vec3 viewPos;
uniform Material material;
uniform Light light;

void main()
{
    // ambient
    // 与上一节类似 通过光源的属性定义了ambient分量
    vec3 ambient = light.ambient * material.ambient;
  	
    // diffuse 
    vec3 norm = normalize(Normal);
    vec3 lightDir = normalize(light.position - FragPos);
    float diff = max(dot(norm, lightDir), 0.0);
    vec3 diffuse = light.diffuse * (diff * material.diffuse);
    
    // specular
    vec3 viewDir = normalize(viewPos - FragPos);
    vec3 reflectDir = reflect(-lightDir, norm);  
    float spec = pow(max(dot(viewDir, reflectDir), 0.0), material.shininess);
    vec3 specular = light.specular * (spec * material.specular);  
        
    vec3 result = ambient + diffuse + specular; //将光线的各个属性写出来了
    FragColor = vec4(result, 1.0);
} 

// 对比参照一下

// #version 330 core
// out vec4 FragColor;

// in vec3 Normal;  
// in vec3 FragPos;  
  
// uniform vec3 lightPos; 
// uniform vec3 viewPos; 
// uniform vec3 lightColor;
// uniform vec3 objectColor;

// void main()
// {
//     // ambient
//     float ambientStrength = 0.5;
//     vec3 ambient = ambientStrength * lightColor;
  	
//     // diffuse 
//     vec3 norm = normalize(Normal);
//     vec3 lightDir = normalize(lightPos - FragPos);
//     float diff = max(dot(norm, lightDir), 0.0);
//     vec3 diffuse = diff * lightColor;
    
//     // specular
//     float specularStrength = 0.9; //强度参数
//     vec3 viewDir = normalize(viewPos - FragPos);
//     vec3 reflectDir = reflect(-lightDir, norm);   //计算反射方向
//     float spec = pow(max(dot(viewDir, reflectDir), 0.0), 32);
//     vec3 specular = specularStrength * spec * lightColor;  
        
//     vec3 result = (ambient + diffuse + specular) * objectColor;
//     FragColor = vec4(result, 1.0);
// } 