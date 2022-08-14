import cv2


img = cv2.imread('E:/Pyton/Bootcamp/Coding/Lesson/lesson_13_task_01/test.jpg')
print(img.shape)
img = cv2.resize(img, (500,500))
print(img.shape)

cv2.imshow('Result', img)

cv2.waitKey(0)