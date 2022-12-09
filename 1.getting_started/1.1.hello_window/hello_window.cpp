#include <glad/glad.h>
#include <GL/glfw3.h>

#include <iostream>

void framebuffer_size_callback(GLFWwindow* window, int width, int height);
void processInput(GLFWwindow *window);

// settings
const unsigned int SCR_WIDTH = 800;
const unsigned int SCR_HEIGHT = 600;

int main()
{
    // glfw: initialize and configure
    // ------------------------------
    // int value: value option
    glfwInit();
    glfwWindowHint(GLFW_CONTEXT_VERSION_MAJOR, 3);
    glfwWindowHint(GLFW_CONTEXT_VERSION_MINOR, 3);
    glfwWindowHint(GLFW_OPENGL_PROFILE, GLFW_OPENGL_CORE_PROFILE);

#ifdef __APPLE__
    glfwWindowHint(GLFW_OPENGL_FORWARD_COMPAT, GL_TRUE);
#endif

    // glfw window creation
    // --------------------
    //���� glfw window����
    GLFWwindow* window = glfwCreateWindow(SCR_WIDTH, SCR_HEIGHT, "LearnOpenGL", NULL, NULL);
    if (window == NULL)
    {
        std::cout << "Failed to create GLFW window" << std::endl;
        glfwTerminate();
        return -1;
    }
    //��������Ϣ������
    //After that we tell GLFW to make the context of our window the main context on the current thread.
    glfwMakeContextCurrent(window);
    //�仯ʱ�Ļص�����
    glfwSetFramebufferSizeCallback(window, framebuffer_size_callback); 

    // glad: load all OpenGL function pointers
    // initialize GLAD before we call any OpenGL function:
    // ͨ�� glad ����os-specific��opengl function��ָ��
    // ---------------------------------------
    if (!gladLoadGLLoader((GLADloadproc)glfwGetProcAddress))
    {
        std::cout << "Failed to initialize GLAD" << std::endl;
        return -1;
    }    

    // render loop
    // -----------
    while (!glfwWindowShouldClose(window))
    {
        // input
        // -----
        processInput(window);

        //rendering
        glClearColor(0.2f, 0.3f, 0.3f, 1.0f); 
        glClear(GL_COLOR_BUFFER_BIT);
        // glfw: swap buffers and poll IO events (keys pressed/released, mouse moved etc.)
        // -------------------------------------------------------------------------------
        //˫������ƣ�
        //Ϊ�˱�����Щ���⣬����Ӧ�ó���Ӧ��˫������������Ⱦ��
        //ǰ̨������������Ļ����ʾ���������ͼ�񣬶�������Ⱦ������Ƶ���̨��������
        //һ��������Ⱦ������ɣ����Ǿͽ���̨������������ǰ̨������������ͼ��Ϳ����ڲ���Ⱦ���������ʾ���Ӷ�������������αӰ��
        glfwSwapBuffers(window);
        glfwPollEvents(); //�¼�����
    }

    // glfw: terminate, clearing all previously allocated GLFW resources.
    // ------------------------------------------------------------------
    glfwTerminate();
    return 0;
}

// process all input: query GLFW whether relevant keys are pressed/released this frame and react accordingly
// ---------------------------------------------------------------------------------------------------------
void processInput(GLFWwindow *window)
{
    //�����¼�
    if(glfwGetKey(window, GLFW_KEY_ESCAPE) == GLFW_PRESS)
        glfwSetWindowShouldClose(window, true);
}

// glfw: whenever the window size changed (by OS or user resize) this callback function executes
// ÿ�����ڴ�С�仯��ʱ�� �ı�ص�����
// ---------------------------------------------------------------------------------------------
void framebuffer_size_callback(GLFWwindow* window, int width, int height)
{
    //���Խ�glViewport�Ŀ������Ϊ��С�������������ӿ�����ʾ������ͼ��
    // (-1 to 1) to (width, height) 
    // make sure the viewport matches the new window dimensions; note that width and 
    // height will be significantly larger than specified on retina displays.
    glViewport(0, 0, width, height);
}
