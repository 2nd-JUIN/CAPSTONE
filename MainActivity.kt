package com.example.myapplication

import android.os.Bundle
import androidx.activity.ComponentActivity
import androidx.activity.compose.setContent
import androidx.compose.foundation.Image
import androidx.compose.foundation.layout.*
import androidx.compose.foundation.shape.CircleShape
import androidx.compose.material3.*
import androidx.compose.runtime.Composable
import androidx.compose.ui.Alignment
import androidx.compose.ui.Modifier
import androidx.compose.ui.res.painterResource
import androidx.compose.ui.text.font.Font
import androidx.compose.ui.text.font.FontFamily
import androidx.compose.ui.tooling.preview.Preview
import androidx.compose.ui.unit.dp
import androidx.compose.ui.unit.sp
import androidx.compose.ui.text.TextStyle
import androidx.compose.ui.layout.ContentScale
import androidx.compose.ui.graphics.Color
import androidx.compose.ui.text.font.FontWeight
import androidx.compose.ui.unit.Dp
import androidx.navigation.NavController
import androidx.navigation.compose.*

import com.example.myapplication.ui.theme.MyApplicationTheme

class MainActivity : ComponentActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContent {
            MyApplicationTheme {
                // NavController 설정
                val navController = rememberNavController()

                NavHost(navController = navController, startDestination = "main") {
                    composable("main") {
                        MainScreen(navController) // MainScreen에 navController 전달
                    }
                    composable("settings") {
                        SettingsScreen() // SettingsScreen 화면을 정의
                    }
                    composable("store") {
                        StoreScreen() // StoreScreen 화면을 정의
                    }
                }
            }
        }
    }
}

@Composable
fun MainScreen(navController: NavController) {
    val customFont = FontFamily(Font(R.font.gamjaflower))

    Box(modifier = Modifier.fillMaxSize()) {
        Image(
            painter = painterResource(id = R.drawable.main),
            contentDescription = "Background Image",
            modifier = Modifier.matchParentSize(),
            contentScale = ContentScale.FillBounds
        )

        Column(
            modifier = Modifier
                .fillMaxSize()
                .padding(16.dp),
            verticalArrangement = Arrangement.Top,
            horizontalAlignment = Alignment.CenterHorizontally
        ) {
            Text(
                text = "공간의 미학",
                style = MaterialTheme.typography.headlineLarge.copy(
                    fontSize = 75.sp,
                    fontFamily = customFont,
                    color = Color.Black,
                    fontWeight = FontWeight.Bold
                ),
                modifier = Modifier.padding(top = 100.dp) // 제목 위치 조정
            )

            Spacer(modifier = Modifier.height(50.dp)) // 제목과 버튼 간격 조정

            Box(
                modifier = Modifier
                    .fillMaxSize()
                    .padding(bottom = 50.dp), // 버튼 일괄 하단으로 내리기
                contentAlignment = Alignment.BottomCenter
            ) {
                Column(
                    modifier = Modifier.fillMaxWidth(),
                    horizontalAlignment = Alignment.CenterHorizontally
                ) {
                    // 스캔 시작 버튼 (위쪽 중앙)
                    CustomButton(text = "스캔 시작", size = 150.dp) { /* TODO: 기능 추가 */ }

                    Spacer(modifier = Modifier.height(20.dp)) // 버튼 간격 조정

                    Row(
                        modifier = Modifier
                            .fillMaxWidth()
                            .padding(horizontal = 20.dp),
                        horizontalArrangement = Arrangement.SpaceBetween
                    ) {
                        // 스토어 버튼 (왼쪽 아래)
                        CustomButton(text = "스토어") {
                            navController.navigate("store") // 스토어 화면으로 이동
                        }

                        // 설정 버튼 (오른쪽 아래)
                        CustomButton(text = "설정") {
                            navController.navigate("settings") // 설정 화면으로 이동
                        }
                    }
                }
            }
        }
    }
}

@Composable
fun SettingsScreen() {
    // 설정 화면~
    Column(
        modifier = Modifier.fillMaxSize().padding(16.dp),
        horizontalAlignment = Alignment.CenterHorizontally,
        verticalArrangement = Arrangement.Center
    ) {
        Text("설정 화면", style = MaterialTheme.typography.headlineMedium)
        Spacer(modifier = Modifier.height(20.dp))
        Text("여기서 설정을 변경할 수 있습니다.", style = MaterialTheme.typography.bodyMedium)
    }
}

@Composable
fun StoreScreen() {
    // 스토어 화면~
    Column(
        modifier = Modifier.fillMaxSize().padding(16.dp),
        horizontalAlignment = Alignment.CenterHorizontally,
        verticalArrangement = Arrangement.Center
    ) {
        Text("스토어 화면", style = MaterialTheme.typography.headlineMedium)
        Spacer(modifier = Modifier.height(20.dp))
        Text("여기에서 다양한 상품을 구매할 수 있습니다.", style = MaterialTheme.typography.bodyMedium)
    }
}

@Composable
fun CustomButton(text: String, size: Dp = 115.dp, onClick: () -> Unit) {
    val customFont = FontFamily(Font(R.font.gamjaflower))

    Button(
        onClick = onClick,
        modifier = Modifier.size(size),
        shape = CircleShape,
        colors = ButtonDefaults.buttonColors(
            containerColor = Color.White.copy(alpha = 0.75f)
        )
    ) {
        Text(
            text = text,
            style = TextStyle(
                fontFamily = customFont,
                fontSize = 25.sp,
                color = Color.Black
            )
        )
    }
}

@Preview(showBackground = true)
@Composable
fun DefaultPreview() {
    MyApplicationTheme {
        MainScreen(rememberNavController()) // 앱의 테마를 설정하는 함수
    }
}
