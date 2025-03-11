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
import com.example.myapplication.ui.theme.MyApplicationTheme

class MainActivity : ComponentActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContent {
            MyApplicationTheme {
                Surface(
                    modifier = Modifier.fillMaxSize(),
                    color = MaterialTheme.colorScheme.background
                ) {
                    MainScreen()
                }
            }
        }
    }
}

@Composable
fun MainScreen() {
    val customFont = FontFamily(Font(R.font.gamjaflower))

    Box(modifier = Modifier.fillMaxSize()) {
        Image(
            painter = painterResource(id = R.drawable.aesthetic),
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
                    .padding(bottom = 50.dp), // 전체적으로 하단으로 내리기
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
                        CustomButton(text = "스토어") { /* TODO: 스토어 기능 */ }

                        // 설정 버튼 (오른쪽 아래)
                        CustomButton(text = "설정") { /* TODO: 설정 기능 */ }
                    }
                }
            }
        }
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
        MainScreen()
    }
}
