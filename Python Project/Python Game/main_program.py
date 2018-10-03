import pygame
import random

BLACK = (0, 0, 0)
WHITE = (255, 255, 255)
RED = (255, 0, 0)
BLUE = (0, 0, 255)

# --- Classes and functions

class Block(pygame.sprite.Sprite):
    def __init__(self, color):
        super().__init__()
        
        self.change_y = 1
        
        self.image = pygame.image.load("meteorGrey_big2.png").convert()
        self.image.set_colorkey(WHITE)

        self.rect = self.image.get_rect()
    
    def update(self):
        self.rect.y += self.change_y
        
        if self.rect.y >= 400:
            self.rect.y = -25


class Player(pygame.sprite.Sprite):
    def __init__(self):
        super().__init__()

        self.image = pygame.image.load("playerShip2_red.png").convert()
        self.image.set_colorkey(WHITE)

        self.rect = self.image.get_rect()

    def update(self):
        pos = pygame.mouse.get_pos()
        pygame.mouse.set_visible(0)

        self.rect.x = pos[0]


class Bullet(pygame.sprite.Sprite):
    def __init__(self):
        super().__init__()

        self.image = pygame.image.load("laserBlue13.png").convert()
        self.image.set_colorkey(WHITE)

        self.rect = self.image.get_rect()

    def update(self):
        self.rect.y -= 3


def create_sprites():
    for i in range(50):
        block = Block(BLUE)
        block.rect.x = random.randrange(screen_width - 15)
        block.rect.y = random.randrange(250)
    
        block_list.add(block)
        all_sprites_list.add(block)
        

def draw_text():
    text = font.render("Score " + str(score), True, WHITE)
    screen.blit(text, [10, 10])  
    
    text = font.render("Level " + str(level), True, WHITE)
    screen.blit(text, [10, 370])
    
    text = font.render("Lives " + str(lives), True, WHITE)
    screen.blit(text, [630, 370])     

# --- Create the window

pygame.init()

screen_width = 700
screen_height = 400
screen = pygame.display.set_mode([screen_width, screen_height])

background_image = pygame.image.load("Screen-shot-2012-04-13-at-2.24.50-PM.jpg").convert()
background_position = [0, 0]

font = pygame.font.SysFont('Calibri', 20, True, False)
font2 = pygame.font.SysFont("serif", 25)

# --- Sprite lists

all_sprites_list = pygame.sprite.Group()
block_list = pygame.sprite.Group()
bullet_list = pygame.sprite.Group()

# --- Create the sprites

create_sprites()

player = Player()
player.rect.y = 370
all_sprites_list.add(player)


done = False

clock = pygame.time.Clock()

level = 1
score = 0
lives = 5

# -------- Main Program Loop -----------

while not done:
    for event in pygame.event.get():
        if event.type == pygame.QUIT:
            done = True

        elif event.type == pygame.MOUSEBUTTONDOWN:
            bullet = Bullet()
            bullet.rect.x = player.rect.x + 12
            bullet.rect.y = player.rect.y
            all_sprites_list.add(bullet)
            bullet_list.add(bullet)
            
    # --- Game logic

    all_sprites_list.update()

    #--- Clear the screen
    screen.fill(WHITE)
    screen.blit(background_image, background_position)
    
    for bullet in bullet_list:

        block_hit_list = pygame.sprite.spritecollide(bullet, block_list, True)

        for block in block_hit_list:
            bullet_list.remove(bullet)
            all_sprites_list.remove(bullet)
            score += 1
            print(score)          
        
        if bullet.rect.y < -10:
            bullet_list.remove(bullet)
            all_sprites_list.remove(bullet)    
    
        if len(block_list) == 0:
            level += 1
            create_sprites()
            block.change_y = level / 2
     
    for block in block_list:
        block_hit_list = pygame.sprite.spritecollide(player, block_list, True)
        for block in block_hit_list:
            # sound
            lives -= 1
        if lives <= 0:
            screen.fill(WHITE)
            text = font2.render("Game Over, click to restart", True, BLACK)
            center_x = (screen_width // 2) - (text.get_width() // 2)
            center_y = (screen_height // 2) - (text.get_height() // 2)
            screen.blit(text, [center_x, center_y])
    
    #--- Draw all the spites
    
    draw_text()
    
    all_sprites_list.draw(screen)

    pygame.display.flip()

    clock.tick(60)

pygame.quit()