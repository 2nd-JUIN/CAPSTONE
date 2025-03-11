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
import androidx.compose.material.icons.Icons
import androidx.compose.material.icons.automirrored.filled.ArrowBack
import com.example.myapplication.ui.theme.MyApplicationTheme

class MainActivity : ComponentActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContent {
            MyApplicationTheme {
                // NavController 설정
                val navController = rememberNavController()

                NavHost(navController = navController, startDestination = "main") {
                    composable("main") { MainScreen(navController) }
                    composable("settings") { SettingsScreen(navController) }
                    composable("store") { StoreScreen(navController) }
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
                    // 스캔 시작 버튼
                    CustomButton(text = "스캔 시작", size = 150.dp) { /* TODO: 기능 추가 */ }

                    Spacer(modifier = Modifier.height(20.dp)) // 버튼 간격 조정

                    Row(
                        modifier = Modifier
                            .fillMaxWidth()
                            .padding(horizontal = 20.dp),
                        horizontalArrangement = Arrangement.SpaceBetween
                    ) {
                        // 스토어 버튼
                        CustomButton(text = "스토어") {
                            navController.navigate("store")
                        }

                        // 설정 버튼
                        CustomButton(text = "설정") {
                            navController.navigate("settings")
                        }
                    }
                }
            }
        }
    }
}

@Composable // 설정 페이지
fun SettingsScreen(navController: NavController) {
    val customFont = FontFamily(Font(R.font.gamjaflower))

    Column(
        modifier = Modifier.fillMaxSize().padding(16.dp),
        horizontalAlignment = Alignment.CenterHorizontally,
        verticalArrangement = Arrangement.Top
    ) {
        // 상단에 뒤로가기 버튼과 앱 이름 배치
        Row(
            modifier = Modifier.fillMaxWidth(),
            horizontalArrangement = Arrangement.Start,
            verticalAlignment = Alignment.CenterVertically
        ) {
            IconButton(onClick = { navController.popBackStack() }) {
                Icon(
                    imageVector = Icons.AutoMirrored.Filled.ArrowBack,
                    contentDescription = "Back",
                    tint = Color.Black
                )
            }
            Text(
                text = "공간의 미학",
                style = MaterialTheme.typography.headlineLarge.copy(
                    fontSize = 30.sp,
                    fontFamily = customFont,
                    color = Color.Black,
                    fontWeight = FontWeight.Bold
                ),
                modifier = Modifier.padding(start = 16.dp)
            )
        }

        Spacer(modifier = Modifier.height(40.dp)) // 상단 요소와 버튼들 사이 간격 조정

        // 버튼들을 두 개씩 세 개의 행으로 배치
        Column(
            modifier = Modifier.fillMaxSize(),
            verticalArrangement = Arrangement.spacedBy(20.dp) // 버튼 간격 조정
        ) {
            // 첫 번째 행
            Row(
                modifier = Modifier.fillMaxWidth(),
                horizontalArrangement = Arrangement.SpaceEvenly
            ) {
                CustomButton(text = "버튼 1", size = 150.dp) { /* TODO: 기능 추가 */ }
                CustomButton(text = "버튼 2", size = 150.dp) { /* TODO: 기능 추가 */ }
            }

            // 두 번째 행
            Row(
                modifier = Modifier.fillMaxWidth(),
                horizontalArrangement = Arrangement.SpaceEvenly
            ) {
                CustomButton(text = "버튼 3", size = 150.dp) { /* TODO: 기능 추가 */ }
                CustomButton(text = "버튼 4", size = 150.dp) { /* TODO: 기능 추가 */ }
            }

            // 세 번째 행
            Row(
                modifier = Modifier.fillMaxWidth(),
                horizontalArrangement = Arrangement.SpaceEvenly
            ) {
                CustomButton(text = "버튼 5", size = 150.dp) { /* TODO: 기능 추가 */ }
                CustomButton(text = "버튼 6", size = 150.dp) { /* TODO: 기능 추가 */ }
            }
        }
    }
}

@Composable // 상점 페이지
fun StoreScreen(navController: NavController) {
    val customFont = FontFamily(Font(R.font.gamjaflower))

    Column(
        modifier = Modifier.fillMaxSize().padding(16.dp),
        horizontalAlignment = Alignment.CenterHorizontally,
        verticalArrangement = Arrangement.Top
    ) {
        // 상단에 뒤로가기 버튼과 앱 이름 배치
        Row(
            modifier = Modifier.fillMaxWidth(),
            horizontalArrangement = Arrangement.Start,
            verticalAlignment = Alignment.CenterVertically
        ) {
            IconButton(onClick = { navController.popBackStack() }) {
                Icon(
                    imageVector = Icons.AutoMirrored.Filled.ArrowBack,
                    contentDescription = "Back",
                    tint = Color.Black
                )
            }
            Text(
                text = "공간의 미학",
                style = MaterialTheme.typography.headlineLarge.copy(
                    fontSize = 30.sp,
                    fontFamily = customFont,
                    color = Color.Black,
                    fontWeight = FontWeight.Bold
                ),
                modifier = Modifier.padding(start = 16.dp)
            )
        }

        Spacer(modifier = Modifier.height(40.dp)) // 상단 요소와 버튼들 사이 간격 조정

        // 버튼들을 가로로 긴 직사각형 버튼으로 배치
        Column(
            modifier = Modifier.fillMaxSize(),
            verticalArrangement = Arrangement.spacedBy(20.dp) // 버튼 간격 조정
        ) {
            // 상품 버튼
            CustomLongButton(text = "상품 1") { /* TODO: 기능 추가 */ }
            CustomLongButton(text = "상품 2") { /* TODO: 기능 추가 */ }
            CustomLongButton(text = "상품 3") { /* TODO: 기능 추가 */ }
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

@Composable
fun CustomLongButton(text: String, onClick: () -> Unit) {
    val customFont = FontFamily(Font(R.font.gamjaflower))

    Button(
        onClick = onClick,
        modifier = Modifier
            .fillMaxWidth()
            .height(60.dp), // 직사각형 버튼 크기 조정
        shape = MaterialTheme.shapes.medium,
        colors = ButtonDefaults.buttonColors(containerColor = Color.White.copy(alpha = 0.75f))
    ) {
        Text(
            text = text,
            style = TextStyle(
                fontFamily = customFont,
                fontSize = 20.sp,
                color = Color.Black
            )
        )
    }
}

@Preview(showBackground = true)
@Composable
fun DefaultPreview() {
    MyApplicationTheme {
        MainScreen(rememberNavController())
    }
}
