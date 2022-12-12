#version 330 core
out vec4 FragColor;

//材料的漫反射和镜面反射属性 需要在cpp文件中进行绑定
struct Material {
    sampler2D diffuse; //使用2D纹理
    sampler2D specular;    //使用2D纹理
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
in vec2 TexCoords; //额外的输入变量 用于纹理
  
uniform vec3 viewPos;
uniform Material material;
uniform Light light;

void main()
{
    // ambient
    // 将环境光的材质颜色设置为漫反射材质颜色同样的值。
    vec3 ambient = light.ambient * texture(material.diffuse, TexCoords).rgb;
  	
    // diffuse 
    vec3 norm = normalize(Normal);
    vec3 lightDir = normalize(light.position - FragPos);
    float diff = max(dot(norm, lightDir), 0.0);
    vec3 diffuse = light.diffuse * diff * texture(material.diffuse, TexCoords).rgb;  
    
    // specular
    vec3 viewDir = normalize(viewPos - FragPos);
    vec3 reflectDir = reflect(-lightDir, norm);  
    float spec = pow(max(dot(viewDir, reflectDir), 0.0), material.shininess);
    // vec3 specular = light.specular * spec * texture(material.specular, TexCoords).rgb;  
    vec3 specular = light.specular * spec * (vec3(1.0) - vec3(texture(material.specular, TexCoords))); 
    // here we inverse the sampled specular color. Black becomes white and white becomes black.
    //让反射贴图的部分发生反转
        
    vec3 result = ambient + diffuse + specular;
    FragColor = vec4(result, 1.0);
} 